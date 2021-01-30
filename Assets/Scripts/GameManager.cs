using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    protected TextMeshProUGUI Text;
    
    public List<RumblePart> Rumbles;

    public List<SoundPart> Sounds;

    public List<VisualPart> Visuals;

    [SerializeField]
    protected float MaxDuration = 300.0f;

    protected float CurrentDuration = -1.0f;

    public float GetCurrentDuration()
    {
        return CurrentDuration;
    }

    public UnityEvent OnGameStart;
    // Start is called before the first frame update
    void Start()
    {
        if (!Instance)
        {
            Instance = this;
        }
        Text.SetText("");
        OnGameStart.Invoke();
        CurrentDuration = MaxDuration;
    }

    void Update()
    {
        CurrentDuration -= Time.deltaTime;
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
    
    public void NewCustomer(){
        //SpawnCustomer()
        
        
        //Generiere Anfrage
    }
}
