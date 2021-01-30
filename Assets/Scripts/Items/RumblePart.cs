using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class RumblePart : ScriptableObject, IDescribable
{
    public AnimationCurve Curve;

    public AnimationCurve HighCurve;
    public float repeatFor = 3.0f;

    [SerializeField]
    protected string Description = "";

    public RumbleCurvesEnum CurveUsage = RumbleCurvesEnum.Both;
    
    RumblePart()
    {
        Curve = new AnimationCurve();
        Curve.AddKey(0.0f, 0.0f);
        HighCurve = new AnimationCurve();
        HighCurve.AddKey(0.0f, 0.0f);
    }

    public string GetDescription()
    {
        return Description;
    }
}
