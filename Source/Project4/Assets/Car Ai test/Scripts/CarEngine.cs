using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour
{
    public Transform path;
    public float maxSteerAngle;
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public float maxMotorTorque;
    public float currentSpeed;
    public float maxSpeed;
    public Vector3 centerOfMass;

    private List<Transform> nodes;
    private int currentNode = 0;
	void Start ()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;
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
	
	void FixedUpdate ()
    {
        ApplySteer();
        Drive();
        CheckWayPointDistance();
	}
    private void ApplySteer()
    {
        Vector3 RelativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
        //RelativeVector /= RelativeVector.magnitude;
        float newSteer = (RelativeVector.x / RelativeVector.magnitude) * maxSteerAngle;
        wheelFL.steerAngle = newSteer;
        wheelFR.steerAngle = newSteer;
    }
    private void Drive()
    {
        currentSpeed = 2 * Mathf.PI * wheelFL.radius * wheelFL.rpm * 60 / 1000;

        if (currentSpeed < maxSpeed)
        {
            wheelFL.motorTorque = maxMotorTorque;
            wheelFR.motorTorque = maxMotorTorque;
        } else
        {
            wheelFL.motorTorque = 0;
            wheelFR.motorTorque = 0;
        }
        
    }
    private void CheckWayPointDistance()
    {
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < 0.5f)
        {
            if(currentNode == nodes.Count - 1)
            {
                currentNode = 0;
            }else
            {
                currentNode++;
            }
        } 
    }
}
