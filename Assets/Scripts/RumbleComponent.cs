using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[Serializable]
public enum RumbleCurvesEnum
{
    Low,
    High,
    Both
}
//see: https://www.youtube.com/watch?v=WSw82nKXibc
//https://github.com/Srfigie/UnityInputSystem_ControlerRumble
public class RumbleComponent : MonoBehaviour
{
    public RumblePart CurrentRumble;

    private bool bExecuteRunning = false;
    private float StartTime = 0.0f;

    public UnityEvent FinishedRumbleItem;


    void FixedUpdate()
    {
        if (bExecuteRunning)
        {
            ExecuteCurve();
        }
    }

    void ExecuteCurve()
    {
        float timePassed = Time.time - StartTime;
        float LowValue = CurrentRumble.Curve.Evaluate(timePassed);
        float HighValue =CurrentRumble.HighCurve.Evaluate(timePassed);
        Gamepad.current.SetMotorSpeeds(LowValue, HighValue);
        //Debug.Log("Low: ("+LowValue+") High: ("+HighValue+")");
        if (timePassed > CurrentRumble.repeatFor)
        {
            StopItem();
        }
    }

    public void PlayRumble(RumblePart InRumble)
    {
        CurrentRumble = InRumble;
        bExecuteRunning = true;
        StartTime = Time.time;
    }

    void StopItem()
    {
        bExecuteRunning = false;
        Gamepad.current.SetMotorSpeeds(0.0f, 0.0f);
        FinishedRumbleItem.Invoke();
    }

    private void OnDisable()
    {
        StopItem();
    }
}
