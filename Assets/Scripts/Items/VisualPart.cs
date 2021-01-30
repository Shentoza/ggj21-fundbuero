using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class VisualPart : ScriptableObject, IDescribable
{
    [SerializeField]
    protected string Description;

    public GameObject Visual;
    
    public string GetDescription()
    {
        return Description;
    }
}
