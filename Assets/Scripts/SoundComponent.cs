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

    public UnityEvent FinishedItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(SoundPart Sound)
    {
        CurrentItem = Sound;
    }

    void StopItem()
    {
        FinishedItem.Invoke();
    }
}
