﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    public GameObject hand;
    public GameObject palm;
    public GameObject player;
    public GameObject item;
    public GameObject pointerLocation;
    public GameObject defaultLocation;
    public GameObject upperArm;
    public GameObject lowerArm;
    public GameObject bodyHand;

    public Transform testBall;


    public Animator anim;

    public bool itemGrabbed;
    public bool itemInReach;


    public float timer;
    public float sensorLength;

    void Start()
    {
        palm = GameObject.Find("Palm");
        player = GameObject.Find("Player");
        hand = this.gameObject;
        anim = hand.GetComponent<Animator>();
        pointerLocation = GameObject.Find("PointerLocation");
        defaultLocation = GameObject.Find("DefaultLocation");
    }


    void Update()
    {
        CheckForObject();

        if (itemInReach || itemGrabbed)
        {
            hand.transform.localScale = Vector3.Lerp(hand.transform.localScale, new Vector3(1, 1, -1), 10 * Time.deltaTime);
            upperArm.transform.localScale = Vector3.Lerp(upperArm.transform.localScale, new Vector3(0.1f, 1, 1), 10 * Time.deltaTime);
            lowerArm.transform.localScale = Vector3.Lerp(lowerArm.transform.localScale, new Vector3(0.1f, 1, 1), 10 * Time.deltaTime);
            bodyHand.transform.localScale = Vector3.Lerp(bodyHand.transform.localScale, new Vector3(0.1f, 1, 1), 10 * Time.deltaTime);
        }
        else
        {
            hand.transform.localScale = Vector3.Lerp(hand.transform.localScale, new Vector3(1, 0.1f, -1), 3 * Time.deltaTime);
            upperArm.transform.localScale = Vector3.Lerp(upperArm.transform.localScale, new Vector3(1, 1, 1), 2 * Time.deltaTime);
            lowerArm.transform.localScale = Vector3.Lerp(lowerArm.transform.localScale, new Vector3(1, 1, 1), 2 * Time.deltaTime);
            bodyHand.transform.localScale = Vector3.Lerp(bodyHand.transform.localScale, new Vector3(1f, 1, 1), 2 * Time.deltaTime);
        }

        if (itemGrabbed)
        {

            item.transform.position = Vector3.Lerp(item.transform.position, palm.transform.position, 20 * Time.deltaTime);
            item.transform.rotation = palm.transform.rotation;
            timer += Time.deltaTime;
            item.transform.localScale = Vector3.Lerp(item.transform.localScale * 0.8f, item.transform.localScale * 0.7f, 1 * Time.deltaTime);

            if (timer >= 0.4f)
            {
                timer = 0;
                item.GetComponent<ItemInformation>().AddToInv();
                Destroy(item);
                item = null;
                itemGrabbed = false;
            }
        }
    }

    public void CheckForObject()
    {

        RaycastHit hit;
        
        Transform sensorStarPos = GameObject.Find("Main Camera").transform;

        Debug.DrawLine(sensorStarPos.position, sensorStarPos.forward * sensorLength);
        if (Physics.Raycast(sensorStarPos.position, sensorStarPos.forward, out hit, sensorLength))
        {
            testBall.transform.position = hit.point;
            if (hit.collider.CompareTag("PickUpCollect") == true)
            {
                itemInReach = true;
                hand.transform.position = Vector3.Lerp(hand.transform.position, defaultLocation.transform.position, 20 * Time.deltaTime);

                if (Input.GetButtonDown("Fire1") && timer == 0)
                {
                    print("Item picked up.");
                    timer = 0;

                    anim.SetTrigger("pHandGrab");

                    item = hit.collider.gameObject;
                    hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    hit.collider.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    itemGrabbed = true;
                }
            }


            if (hit.collider.CompareTag("PickUpInteract") == true)
            {
                print("Interact in reach");
                itemInReach = true;
                hand.transform.position = Vector3.Lerp(hand.transform.position, pointerLocation.transform.position, 10 * Time.deltaTime);

                if (Input.GetButtonDown("Fire1"))
                {
                    print("Interacted");


                    anim.SetTrigger("pHandPress");


                }
            }else
            {
                print(hit.collider.transform.name);
            }

            if (hit.collider.CompareTag("PickUpInteract") == false && hit.collider.CompareTag("PickUpCollect") == false)
            {
                itemInReach = false;

            }


        }
        else
        {
            itemInReach = false;
        }

    }
}
