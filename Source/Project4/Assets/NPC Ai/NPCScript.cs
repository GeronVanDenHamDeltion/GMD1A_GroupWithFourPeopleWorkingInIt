using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCScript : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent;
    public bool follow = false;
    public float timer;
    public GameObject player;


    public List<GameObject> objectives = new List<GameObject>();

    

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
        target = objectives[Random.Range(0, objectives.Count)];
        rb = this.gameObject.GetComponent<Rigidbody>();
        anim = this.gameObject.GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();
        


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

        if (!follow)
        {
            timer = timer + Random.Range(0.01f, 1);
            if (timer >= 1000)
            {
                timer = 0;
                target = objectives[Random.Range(0, objectives.Count)];
            }
        }
        else
        {
            target = player;
            if (Input.GetButtonDown("DebugToggleAiFollow"))
            {
                target = objectives[Random.Range(0, objectives.Count)];
            }
        }

    }

    void Update()
    {
        if(Input.GetButtonDown("DebugToggleAiFollow"))
        {
            follow = !follow;      
        }
        


        agent.SetDestination(target.transform.position);

        if (agent.velocity != Vector3.zero)
        {
            animationState = AnimationState.Walk;
        }
        else
        {
            animationState = AnimationState.Idle;
        }
    }
}
