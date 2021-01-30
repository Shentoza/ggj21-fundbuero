using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class RumblePart : ScriptableObject
{
    public AnimationCurve Curve;
    public float repeatFor = 3.0f;
}
