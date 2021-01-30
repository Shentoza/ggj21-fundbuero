using System;
using UnityEngine;
using UnityEngine.InputSystem;

//see: https://www.youtube.com/watch?v=WSw82nKXibc
//https://github.com/Srfigie/UnityInputSystem_ControlerRumble
public class RumbleComponent : MonoBehaviour
{
    public FoundItem CurrentItem;

    private bool bExecuteRunning = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (bExecuteRunning)
        {
            ExecuteCurve();
        }
        else
        {
            StopMotors();
        }
    }

    void ExecuteCurve()
    {
        float CurrentVal = CurrentItem.Rumble.Curve.Evaluate(Time.time);
        Gamepad.current.SetMotorSpeeds(CurrentVal, CurrentVal);
    }

    public void PlayItem(FoundItem InItem)
    {
        CurrentItem = InItem;
        bExecuteRunning = true;
        
    }

    void StopMotors()
    {
        Gamepad.current.SetMotorSpeeds(0.0f, 0.0f);
    }

    private void OnDisable()
    {
        StopMotors();
    }
}
