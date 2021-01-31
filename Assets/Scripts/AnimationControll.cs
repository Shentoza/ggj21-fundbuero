using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControll : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        animator.SetBool("isPlaying", true);
    }

}
