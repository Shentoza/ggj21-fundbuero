using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class SoundPart : ScriptableObject
{
    [EventRef] public string Event;
}
