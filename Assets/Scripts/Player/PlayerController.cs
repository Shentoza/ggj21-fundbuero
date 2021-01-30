using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    protected RumbleComponent Rumbler;
    

    private void Start()
    {
        Rumbler = GetComponent<RumbleComponent>();
        Rumbler.FinishedRumbleItem.AddListener(OnRumbleFinish);
    }

    public void Look(InputAction.CallbackContext Context)
    {
        //Look stuff
    }

    public void Use(InputAction.CallbackContext Context)
    {
        if (Context.started)
        {
            var randomizeItem = GameManager.Instance.RandomizeItem();
            Debug.Log(randomizeItem.Rumble.name);
            Rumbler.PlayItem(randomizeItem);
        }
    }

    void OnRumbleFinish()
    {
        Debug.Log("Rumble Finished");
    }

    void OnSoundFinish()
    {
        Debug.Log("Sound Finished");
    }


}
