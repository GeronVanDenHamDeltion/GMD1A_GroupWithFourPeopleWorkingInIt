using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public enum AnimationState
    {
        Idle,
        Walk,
        Run
    }
    public Rigidbody rb;
    public Animator anim;
    public AnimationState animationState;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        anim = this.gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if ( animationState == AnimationState.Idle )
        {
            anim.SetBool("bNPCidle", true);
            anim.SetBool("bNPCwalk", false);
            anim.SetBool("bNPCrun", false);
        }

        if (animationState == AnimationState.Walk)
        {
            anim.SetBool("bNPCwalk", true);
            anim.SetBool("bNPCidle", false);
            anim.SetBool("bNPCrun", false);
        }

        if (animationState == AnimationState.Run)
        {
            anim.SetBool("bNPCrun", true);
            anim.SetBool("bNPCidle", false);
            anim.SetBool("bNPCwalk", false);
        }      
    }
}
