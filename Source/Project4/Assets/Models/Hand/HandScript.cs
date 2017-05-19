using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    public GameObject hand;
    public GameObject player;
    public Animator anim;

    
    public float sensorLength;


    void Start()
    {
        player = GameObject.Find("Player");
        hand = this.gameObject;
        anim = hand.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        CheckForObject();
    }

    public void CheckForObject()
    {
        RaycastHit hit;
        Transform sensorStarPos = GameObject.Find("Main Camera").transform;

        Debug.DrawRay(sensorStarPos.position, sensorStarPos.forward * sensorLength);
        if (Physics.Raycast(sensorStarPos.position, sensorStarPos.transform.forward, out hit, sensorLength))
        {
            if (hit.collider.CompareTag("Terrain") == false)
            {
                if (hit.collider.CompareTag("PickUpCollect") == true)
                {
                    print("pickup");
                }
            }
        }
    }


}
