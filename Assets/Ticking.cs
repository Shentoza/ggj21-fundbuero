using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticking : MonoBehaviour
{
    [SerializeField] protected float BPM = 98.0f;

    private float Delay = 0.0f;

    private float CurrentDelay = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Delay = 60.0f / (BPM);
        CurrentDelay = Delay;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CurrentDelay -= Time.fixedDeltaTime;
        if (CurrentDelay < 0.0f)
        {
            var old = transform.rotation.eulerAngles;
            old.z += 5.0f;
            transform.rotation = Quaternion.Euler(old);
            CurrentDelay = Delay;
        }
    }
}
