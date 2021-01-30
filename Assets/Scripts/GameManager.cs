using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public List<RumblePart> Rumbles;

    public List<SoundPart> Sounds;

    public List<MeshRenderer> Meshes;
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
        FoundItem newItem = ScriptableObject.CreateInstance<FoundItem>();

        if (Rumbles.Count > 0)
        {
            int rumbleIndex = Random.Range(0, Rumbles.Count);
            newItem.Rumble = (RumblePart)Rumbles[rumbleIndex];
        }

        if (Sounds.Count > 0)
        {
            int soundIndex = Random.Range(0, Sounds.Count);
            newItem.Sound = (SoundPart)Sounds[soundIndex];
        }

        if (Meshes.Count > 0)
        {
            int meshIndex = Random.Range(0, Meshes.Count);
            newItem.Mesh = (MeshRenderer) Meshes[meshIndex];
        }

        return newItem;
    }
}
