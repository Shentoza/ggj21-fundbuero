using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public ArrayList Rumbles;

    public ArrayList Sounds;

    public ArrayList Meshes;
    // Start is called before the first frame update
    void Start()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public FoundItem RandomizeItem()
    {
        FoundItem NewItem = ScriptableObject.CreateInstance<FoundItem>();
        int RumbleIndex = Random.Range(0, Rumbles.Count);
        NewItem.Rumble = (RumblePart)Rumbles[RumbleIndex];

        int SoundIndex = Random.Range(0, Sounds.Count);
        NewItem.Sound = (SoundPart)Sounds[SoundIndex];

        int MeshIndex = Random.Range(0, Meshes.Count);
        NewItem.Mesh = (MeshRenderer) Meshes[MeshIndex];


        return NewItem;
    }
}
