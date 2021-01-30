using System.Collections;
using FMODUnity;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class FoundItem : ScriptableObject
{
    public static ArrayList Rumbles;

    public RumblePart Rumble;

    public FMODEventPlayable Sound;

    public MeshRenderer Mesh;
}