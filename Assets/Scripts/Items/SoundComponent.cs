using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(StudioEventEmitter))]
public class SoundComponent : MonoBehaviour
{
    protected SoundPart CurrentItem;

    protected StudioEventEmitter Emitter;

    private bool bExecutionRunning = false;

    public UnityEvent FinishedItem;
    // Start is called before the first frame update
    void Start()
    {
        Emitter = GetComponent<StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bExecutionRunning && !Emitter.IsPlaying())
        {
            StopSound();
        }
    }

    public void PlaySound(SoundPart Sound)
    {
        CurrentItem = Sound;
        bExecutionRunning = true;
        Emitter.Event = Sound.Event;
        Emitter.Play();
    }

    void StopSound()
    {
        bExecutionRunning = false;
        FinishedItem.Invoke();
    }
}
