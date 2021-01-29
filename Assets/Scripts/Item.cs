using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : ScriptableObject
{
    void Rumble()
    {
        Handheld.Vibrate();
    }

    void PlaySound()
    {
        
    }

    public Mesh DisplayingMesh;

    public UnityEvent OnSelect;

    public UnityEvent OnDeselect;
}
