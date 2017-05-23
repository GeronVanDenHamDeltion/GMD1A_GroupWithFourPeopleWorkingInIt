using System.Collections;
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

        if (Input.GetKey("e"))
        {

            hand.transform.localScale = Vector3.Lerp(hand.transform.localScale, new Vector3(1, 5, -1), 1 * Time.deltaTime);
        }

        if (itemInReach || itemGrabbed)
        {
            hand.transform.localScale = Vector3.Lerp(hand.transform.localScale, new Vector3(1, 1, -1), 10 * Time.deltaTime);
        }
        else
        {
            hand.transform.localScale = Vector3.Lerp(hand.transform.localScale, new Vector3(1,0.1f,-1), 2 * Time.deltaTime);
        }

        if (itemGrabbed)
        {
            
            item.transform.position = Vector3.Lerp(item.transform.position, palm.transform.position, 20 * Time.deltaTime);
            item.transform.rotation = palm.transform.rotation;
            timer += Time.deltaTime;
            item.transform.localScale = Vector3.Lerp(item.transform.localScale, item.transform.localScale * 0.5f, 10 * Time.deltaTime);
            
            if (timer >= 0.4f)
            {
                timer = 0;
                item.SetActive(false);
                item = null;
                itemGrabbed = false;
            }
        }
    }

    public void CheckForObject()
    {
        
        RaycastHit hit;

        Transform sensorStarPos = GameObject.Find("Main Camera").transform;

        Debug.DrawRay(sensorStarPos.position, sensorStarPos.forward * sensorLength);
        if (Physics.Raycast(sensorStarPos.position, sensorStarPos.transform.forward, out hit, sensorLength))
        {
            if (hit.collider.CompareTag("Terrain"))
            {
                itemInReach = false;
            }

            if (hit.collider.CompareTag("Terrain") == false)
            {


                if (hit.collider.CompareTag("PickUpCollect") == true)
                {
                    print("pickup in reach");
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



                else if (hit.collider.CompareTag("PickUpInteract") == true)
                {
                    print("Interact in reach");
                    itemInReach = true;
                    hand.transform.position = Vector3.Lerp(hand.transform.position, pointerLocation.transform.position, 10 * Time.deltaTime);

                    if (Input.GetButtonDown("Fire1"))
                    {
                        print("Interacted");

                        
                        anim.SetTrigger("pHandPress");


                    }
                }
                else
                {
                    
                }

            }
        }
        else
        {
            itemInReach = false;
        }
    }
}
