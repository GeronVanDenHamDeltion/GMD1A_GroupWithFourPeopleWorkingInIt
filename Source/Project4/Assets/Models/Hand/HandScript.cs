using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    public GameObject hand;
    public Animator anim;

    void Start()
    {
        hand = this.gameObject;
        anim = hand.GetComponent<Animator>();
    }

}
