using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    public GameObject hand;
    public GameObject palm;
    public GameObject player;
    public GameObject item;
    public Animator anim;
    public bool itemGrabbed;
    public float timer;

    
    public float sensorLength;


    void Start()
    {
        palm = GameObject.Find("Palm");
        player = GameObject.Find("Player");
        hand = this.gameObject;
        anim = hand.GetComponent<Animator>();
    }

    void Update()
    {
        CheckForObject();

        if(itemGrabbed)
        {
            
            item.transform.position = Vector3.Lerp(item.transform.position, palm.transform.position, 20 * Time.deltaTime);
            item.transform.rotation = palm.transform.rotation;
            timer += Time.deltaTime;
            //item.transform.localScale += new Vector3.Lerp(timer, timer, timer);
            item.transform.localScale = Vector3.Lerp(item.transform.localScale, item.transform.localScale * 0.5f, 30 * Time.deltaTime);
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
            if (hit.collider.CompareTag("Terrain") == false)
            {
                if (hit.collider.CompareTag("PickUpCollect") == true)
                {
                    print("pickup in reach");

                    if (Input.GetButtonDown("Fire1"))
                    {
                        timer = 0;

                        anim.SetTrigger("pHandGrab");
                        //hit.collider.gameObject.SetActive(false);
                        //palm.transform.position = Vector3.Lerp(transform.position, hit.collider.gameObject.transform.position, Time.time);
                        //palm.transform.position = Vector3.Lerp(palm.transform.position, hit.collider.gameObject.transform.position, 20);

                        item = hit.collider.gameObject;
                        hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = false;
                        hit.collider.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                        itemGrabbed = true;

                        
                    }
                }
            }
        }
    }
}
