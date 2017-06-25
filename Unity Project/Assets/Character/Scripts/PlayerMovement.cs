using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float runningSpeed;
    public float walkingSpeed;
    public float jumpspeed;
    public bool jumppushed;
    public float timer;

    public PlayerBodyScript playerBodyScript;

    void FixedUpdate()
    {

        Walk();
    }

    void Fixedupdate()
    { 
        float vertical = Input.GetAxis("Vertical") * speed;
        float horizontal = Input.GetAxis("Horizontal") * speed;
        vertical *= Time.deltaTime;
        horizontal *= Time.deltaTime;

        transform.Translate(horizontal, 0, vertical);  

        

    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && jumppushed == false)
        {
            Jump();
        }
        if (jumppushed == true)
        {
            timer = timer + Time.deltaTime;
        }
        if (jumppushed == true && timer > 1)
        {
            timer = 0;
            jumppushed = false;
        }
    }

    public void Walk()
    {
        float vertical = Input.GetAxis("Vertical") * speed;
        float horizontal = Input.GetAxis("Horizontal") * speed;
        vertical *= Time.deltaTime;
        horizontal *= Time.deltaTime;

        transform.Translate(horizontal, 0, vertical);


        if(Input.GetButton("Fire3"))
        {
            
            if (vertical > 0)
            {
                playerBodyScript.animationState = PlayerBodyScript.AnimationState.Run;
                speed = runningSpeed;
            }
        }
        else if ( horizontal == 0 && vertical == 0)
        {
            playerBodyScript.animationState = PlayerBodyScript.AnimationState.Idle;
        }

        else
        {
            speed = walkingSpeed;
            playerBodyScript.animationState = PlayerBodyScript.AnimationState.Walk;
        }

        if(vertical == 0 && horizontal == 0 )
        {
            playerBodyScript.animationState = PlayerBodyScript.AnimationState.Idle;
        }

    }

    public void Jump()
    {
        this.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpspeed);
        jumppushed = true;
        playerBodyScript.Jump();
    }

}
