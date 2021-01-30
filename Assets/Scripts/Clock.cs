using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        StartTimer();

    }

    public void StartTimer()
    {
        animator.SetBool("IsTicking", true);
    }
}
