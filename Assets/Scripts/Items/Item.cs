using System.Collections;
using FMODUnity;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class FoundItem : ScriptableObject
{
    public static ArrayList Rumbles;

    public RumblePart Rumble;

    public SoundPart Sound;

    public VisualPart Visuals;

    public float Compare(FoundItem other)
    {
        float Equals = 0.0f;
        float Max = 3.0f;

        Equals += other.Rumble.Equals(Rumble) ? 1.0f : 0.0f;
        Equals += other.Sound.Equals(Sound) ? 1.0f : 0.0f;
        Equals += other.Visuals.Equals(Visuals) ? 1.0f : 0.0f;

        return Equals / Max;
    }

}