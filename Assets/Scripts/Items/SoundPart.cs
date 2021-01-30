using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class SoundPart : ScriptableObject, IDescribable
{
    [EventRef] public string Event;

    [SerializeField]
    protected string Description;
    public string GetDescription()
    {
        return Description;
    }
    
    
    
}
