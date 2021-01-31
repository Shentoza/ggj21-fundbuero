using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    [SerializeField]
    private float Deg = 5.0f;

    // Update is called once per frame
    public void OnBeat()
    {
        transform.Rotate(0, 0, -Deg);
    }
}
