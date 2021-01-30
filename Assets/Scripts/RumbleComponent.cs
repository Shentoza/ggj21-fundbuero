using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

//see: https://www.youtube.com/watch?v=WSw82nKXibc
//https://github.com/Srfigie/UnityInputSystem_ControlerRumble
public class RumbleComponent : MonoBehaviour
{
    public FoundItem CurrentItem;

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
        float CurrentVal = CurrentItem.Rumble.Curve.Evaluate(timePassed);
        Debug.Log(CurrentVal);
        Gamepad.current.SetMotorSpeeds(CurrentVal, CurrentVal);
        if (timePassed > CurrentItem.Rumble.repeatFor)
        {
            StopItem();
        }
    }

    public void PlayItem(FoundItem InItem)
    {
        CurrentItem = InItem;
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
