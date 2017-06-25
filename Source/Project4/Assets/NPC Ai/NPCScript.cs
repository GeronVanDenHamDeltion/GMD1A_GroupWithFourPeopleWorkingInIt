using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCScript : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent;
    static bool follow = false;
    public float timer;
    public GameObject player;
    //public GameObject spawn;
    //public CameraEffects camEffects;
    //public Material shirt;
    //public Material pants;
    //public float myDistanceToPlayer;

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
    public GameObject destinations;

    void Start()
    {
        //spawn = GameObject.Find("Spawn");
        //camEffects = player.transform.GetChild(0).gameObject.GetComponent<CameraEffects>();
        Transform[] pathTransform = destinations.GetComponentsInChildren<Transform>();
        for (int i = 0; i < pathTransform.Length; i++)
        {
            if (pathTransform[i] != destinations.transform)
            {
                objectives.Add(pathTransform[i].gameObject);
            }
        }
        target = objectives[Random.Range(0, objectives.Count)];
        rb = this.gameObject.GetComponent<Rigidbody>();
        anim = this.gameObject.GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();

        //shirt.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        //pants.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

    }

    void FixedUpdate()
    {
        //myDistanceToPlayer = Vector3.Distance(player.transform.position, this.gameObject.transform.position);
        //if (myDistanceToPlayer <= 5)
        //{
        //    camEffects.closeEnemy = this.gameObject;
        //}

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
