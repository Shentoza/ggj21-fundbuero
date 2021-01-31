using System;
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

    protected string CurrentText;

    private bool bPlayAnimation = true;

    void Awake()
    {
        CustomerSystem.OnRequestStartedAction += OnNewRequest;
    }

    private void OnDisable()
    {
        CustomerSystem.OnRequestStartedAction -= OnNewRequest;
    }

    /*void Update()
    {
        // Do Animationstuff
        //bPlayAnimation = falseru
    }*/
    
    string GetDescription(IDescribable Description)
    {
        string baseDescr = "{0}";
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
        return string.Format(baseDescr, Description.GetDescription());
    }

    public void OnNewRequest(FoundItem Item, int NumOfRandomGenerates)
    {
        CurrentText = GetDescription(Item.Visuals);
        CurrentText += "\n " + GetDescription(Item.Rumble);
        CurrentText += "\n " + GetDescription(Item.Sound);
        
        DescriptionText.SetText(CurrentText);
        bPlayAnimation = false;
    }
    
}
