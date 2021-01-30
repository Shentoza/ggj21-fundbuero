using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DescriptionComponent : MonoBehaviour
{

    [SerializeField]
    protected string RumbleDescription;
    
    [SerializeField]
    protected string SoundDescription;
    
    [SerializeField]
    protected string VisibleDescription;

    [SerializeField]
    protected TextMeshProUGUI DescriptionText;
    


    void SetDescription(IDescribable Description)
    {
        string baseDescr;
        if (Description is RumblePart)
        {
            baseDescr = RumbleDescription;
        }
        else if (Description is SoundPart)
        {
            baseDescr = SoundDescription;
        }
        else if (Description is VisualPart)
        {
            baseDescr = VisibleDescription;
        }
       // DescriptionText
    }
}
