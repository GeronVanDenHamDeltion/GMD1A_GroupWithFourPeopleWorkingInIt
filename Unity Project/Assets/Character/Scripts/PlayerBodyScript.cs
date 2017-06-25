using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyScript : MonoBehaviour {

    public Animator anim;

    public enum AnimationState { Idle, Walk, Run, Jump };
    public AnimationState animationState;

    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    public void Jump()
    {
        anim.SetTrigger("pJump");
    }

    void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if(!Input.GetButton("Fire3"))
        {
            if (vertical != 0 || horizontal != 0)
            {
                animationState = AnimationState.Walk;
            }
            else
            {
                animationState = AnimationState.Idle;
            }
        }


        if (animationState == AnimationState.Idle)
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
