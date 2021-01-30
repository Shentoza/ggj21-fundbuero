using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    protected TextMeshProUGUI Text;
    
    public List<RumblePart> Rumbles;

    public List<SoundPart> Sounds;

    public List<VisualPart> Visuals;
    // Start is called before the first frame update
    void Start()
    {
        if (!Instance)
        {
            Instance = this;
        }
        Text.SetText("");
    }
    
    public void SetItemDescription(string InText)
    {
        Text.SetText(InText);
    }

    public FoundItem RandomizeItem()
    {
        FoundItem newItem = ScriptableObject.CreateInstance<FoundItem>();

        if (Rumbles.Count > 0)
        {
            int rumbleIndex = Random.Range(0, Rumbles.Count);
            newItem.Rumble = Rumbles[rumbleIndex];
        }

        if (Sounds.Count > 0)
        {
            int soundIndex = Random.Range(0, Sounds.Count);
            newItem.Sound = Sounds[soundIndex];
        }

        if (Visuals.Count > 0)
        {
            int meshIndex = Random.Range(0, Visuals.Count);
            newItem.Visuals = Visuals[meshIndex];
        }

        return newItem;
    }
}
