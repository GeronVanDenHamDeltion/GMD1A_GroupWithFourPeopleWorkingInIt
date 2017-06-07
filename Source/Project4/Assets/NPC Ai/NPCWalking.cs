using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalking : MonoBehaviour
{
    public Transform path;
    public float Speed;
    public float maxspeed;
    public float wayPointDistance;
    public bool stop;
    public float turnSpeed;
    public List<Transform> nodes;
    public int currentNode = 0;
    public NPCScript stateScript;
    public bool triggerMode;
    public GameObject player;

    [Header("Sensors")]
    public float sensorLength;
    public Vector3 frontSensorPos;

    private Vector3 direction;
    private Quaternion lookRotationQuat;
    private bool avoiding = false;
    private float targetSteerAngle = 0f;

    void Start ()
    {
        Transform[] pathTransform =path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransform.Length; i++)
        {
            if (pathTransform[i] != path.transform)
            {
                nodes.Add(pathTransform[i]);
            }
        }
    }
	void Update()
    {
    }
	void FixedUpdate ()
    {
        Walk();
        CheckWayPointDistance();
        if (triggerMode == false)
        {
            Braking();
            Sensor();
        }
	}
    private void Walk()
    {
        if (triggerMode == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, nodes[currentNode].position, Speed);
        }else
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Speed);
            stateScript.animationState = NPCScript.AnimationState.Run;
        }
    }
    private void CheckWayPointDistance()
    {
        if (triggerMode == true)
        {
            direction = (player.transform.position - transform.position).normalized;
            lookRotationQuat = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotationQuat, Time.deltaTime * turnSpeed);
            return;
        }
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < wayPointDistance)
        {
            StartCoroutine(rotationspeed());
        }
    }
    public IEnumerator rotationspeed()
    {
        maxspeed = maxspeed / 2;
        if (currentNode == nodes.Count - 1)
        {
            currentNode = 0;
        }
        else
        {
            currentNode++;
        }
        direction = (nodes[currentNode].position - transform.position).normalized;
        lookRotationQuat = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotationQuat, Time.deltaTime * turnSpeed);
        yield return new WaitForSeconds(2);
        maxspeed = maxspeed * 2;
    }
    private void Braking()
    {
        if (stop == true)
        {
            Speed = 0;
        }
        else
        {
            Speed = maxspeed;
        }
    }
    private void Sensor()
    {
        RaycastHit hit;
        Vector3 sensorStartPos = transform.position;
        sensorStartPos = sensorStartPos + frontSensorPos;
        avoiding = false;
        if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength))
        {
            Debug.DrawLine(sensorStartPos, hit.point);
            stop = true;
            stateScript.animationState = NPCScript.AnimationState.Idle;
        }else
        {
            stop = false;
            stateScript.animationState = NPCScript.AnimationState.Walk;
        }
    }
}
