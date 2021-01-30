using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(RumbleComponent),typeof(SoundComponent))]
public class PlayerController : MonoBehaviour
{
    protected RumbleComponent Rumbler;

    protected SoundComponent SoundComp;

    private FoundItem CurrentItem;

    [Range(0, 5)] public float TimeBetweenSteps = 0.5f;

    private void Start()
    {
        Rumbler = GetComponent<RumbleComponent>();
        Rumbler.FinishedRumbleItem.AddListener(OnRumbleFinish);

        SoundComp = GetComponent<SoundComponent>();
        SoundComp.FinishedItem.AddListener(OnSoundFinish);
    }

    public void Look(InputAction.CallbackContext Context)
    {
        //Look stuff
    }

    public void Use(InputAction.CallbackContext Context)
    {
        if (Context.started)
        {
            UseItem(GameManager.Instance.RandomizeItem());
        }
    }

    void UseItem(FoundItem Item)
    {
        CurrentItem = Item;
        PlayRumble();
    }

    void OnRumbleFinish()
    {
        //Debug.Log("Rumble Finished");
        Invoke("PlaySound", TimeBetweenSteps);

    }

    void PlayRumble()
    {
        Debug.Log(CurrentItem.Rumble.name);
        Rumbler.PlayRumble(CurrentItem.Rumble);
        GameManager.Instance.SetItemDescription(CurrentItem.Rumble.GetDescription());
    }

    void PlaySound()
    {
        Debug.Log(CurrentItem.Sound.name);
        SoundComp.PlaySound(CurrentItem.Sound);
        GameManager.Instance.SetItemDescription(CurrentItem.Sound.GetDescription());
    }

    void OnSoundFinish()
    {
        Debug.Log("Sound Finished");
    }

    void OnItemFinish()
    {
        GameManager.Instance.SetItemDescription("");   
    }


}
