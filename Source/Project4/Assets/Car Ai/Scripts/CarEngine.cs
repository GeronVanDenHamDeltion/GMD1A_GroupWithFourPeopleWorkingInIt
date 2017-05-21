using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour
{
    public Transform path;
    public float turnSpeed;
    public float maxSteerAngle;
    public float maxBrakeTorque;
    public float maxMotorTorque;
    public float currentSpeed;
    public float maxSpeed;
    public Vector3 centerOfMass;
    public bool brake;
    public bool stillbrake;
    public float wayPointDistance;
    public bool crossing;
    public bool brakingReverse;

    [Header("Wheels")]
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelRL;
    public WheelCollider wheelRR;

    [Header("Sensors")]
    public float sensorLength;
    public Vector3 frontSensorPos;
    public float sideSensorPos;
    public float frontSensorAngle;
    public float sideWalkPos;

    private bool avoiding = false;
    public List<Transform> nodes;
    public int currentNode = 0;
    private float targetSteerAngle = 0f;

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
	void Update()
    {
        if (brake == true && currentSpeed < 0.01f && stillbrake == false)
        {
            brake = false;
        }
    }
	void FixedUpdate ()
    {
        ApplySteer();
        Drive();
        CheckWayPointDistance();
        Braking();
        Sensors();
        LerpToSteerAngle();
	}
    private void ApplySteer()
    {
        if (avoiding == true)
        {
            return;
        }
        Vector3 RelativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
        float newSteer = (RelativeVector.x / RelativeVector.magnitude) * maxSteerAngle;
        targetSteerAngle = newSteer;
    }
    private void Drive()
    {
        currentSpeed = 2 * Mathf.PI * wheelFL.radius * wheelFL.rpm * 60 / 1000;

        if (currentSpeed < maxSpeed && brake == false)
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
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < wayPointDistance)
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
    private void Braking()
    {
        if (brake == true)
        {
            wheelRL.brakeTorque = maxBrakeTorque;
            wheelRR.brakeTorque = maxBrakeTorque;
            wheelFL.brakeTorque = maxBrakeTorque;
            wheelFR.brakeTorque = maxBrakeTorque;
        }
        else
        {
            wheelFL.brakeTorque = 0;
            wheelFR.brakeTorque = 0;
            wheelRL.brakeTorque = 0;
            wheelRR.brakeTorque = 0;
        }
    }
    private void Sensors()
    {
        RaycastHit hit;
        Vector3 sensorStarPos = transform.position;
        sensorStarPos += transform.forward * frontSensorPos.z;
        float avoidMultiplier = 0;
        avoiding = false;

        //Front Right Side Sensors
        sensorStarPos += transform.right * sideSensorPos;
        if (Physics.Raycast(sensorStarPos, transform.forward, out hit, sensorLength))
        {
            if (hit.collider.CompareTag("Terrain") == false && hit.collider.CompareTag("CarTrigger") == false)
            {
                if (hit.collider.CompareTag("SideWalk") == true)
                {
                    Debug.DrawLine(sensorStarPos, hit.point);
                    if (Vector3.Distance(hit.point, sensorStarPos) > sideWalkPos)
                    {
                        avoiding = true;
                        avoidMultiplier -= 1f;
                    }
                }
                else
                {
                    Debug.DrawLine(sensorStarPos, hit.point);
                    avoiding = true;
                    avoidMultiplier -= 1f;
                }
                
            }
        }
        
        //Front Right Angle Sensors
        if (Physics.Raycast(sensorStarPos, Quaternion.AngleAxis(frontSensorAngle, transform.up) * transform.forward, out hit, sensorLength))
        {
            if (hit.collider.CompareTag("Terrain") == false && hit.collider.CompareTag("CarTrigger") == false)
            {
                if (hit.collider.CompareTag("SideWalk") == true)
                {
                    Debug.DrawLine(sensorStarPos, hit.point);
                    if (Vector3.Distance(hit.point, sensorStarPos) > sideWalkPos)
                    {
                        avoiding = true;
                        avoidMultiplier -= 0.5f;
                    }
                }
                else
                {
                    Debug.DrawLine(sensorStarPos, hit.point);
                    avoiding = true;
                    avoidMultiplier -= 0.5f;
                }
            }
        }

        //Front left Side Sensors
        sensorStarPos -= transform.right * sideSensorPos *2;
        if (Physics.Raycast(sensorStarPos, transform.forward, out hit, sensorLength))
        {
            if (hit.collider.CompareTag("Terrain") == false && hit.collider.CompareTag("CarTrigger") == false)
            {
                if (hit.collider.CompareTag("SideWalk") == true)
                {
                    Debug.DrawLine(sensorStarPos, hit.point);
                    if (Vector3.Distance(hit.point, sensorStarPos) > sideWalkPos)
                    {
                        avoiding = true;
                        avoidMultiplier += 1f;
                    }
                }
                else
                {
                    Debug.DrawLine(sensorStarPos, hit.point);
                    avoiding = true;
                    avoidMultiplier += 1f;
                }
            }
        }
        
        //Front Left Angle Sensors
        if (Physics.Raycast(sensorStarPos, Quaternion.AngleAxis(-frontSensorAngle, transform.up) * transform.forward, out hit, sensorLength))
        {
            if (hit.collider.CompareTag("Terrain") == false &&  hit.collider.CompareTag("CarTrigger") == false)
            {
                if (hit.collider.CompareTag("SideWalk") == true)
                {
                    Debug.DrawLine(sensorStarPos, hit.point);
                    if (Vector3.Distance(hit.point, sensorStarPos) > sideWalkPos)
                    {
                        avoiding = true;
                        avoidMultiplier += 0.5f;
                    }
                }
                else
                {
                    Debug.DrawLine(sensorStarPos, hit.point);
                    avoiding = true;
                    avoidMultiplier += 0.5f;
                }
            }
        }
        //front Center Sensor
        if (avoidMultiplier < 0.4f && avoidMultiplier > -0.4f)
        {
            if (Physics.Raycast(sensorStarPos, transform.forward, out hit, sensorLength))
            {
                if (hit.collider.CompareTag("Terrain") == false &&  hit.collider.CompareTag("CarTrigger") == false)
                {
                    if (hit.collider.CompareTag("SideWalk") == true)
                    {
                        Debug.DrawLine(sensorStarPos, hit.point);
                        if (Vector3.Distance(hit.point, sensorStarPos) > sideWalkPos)
                        {
                            avoiding = true;
                            if (hit.normal.x < 0)
                            {
                                avoidMultiplier = -1;
                            }
                            else
                            {
                                avoidMultiplier = 1;
                            }
                        }

                    }
                    else
                    {
                        Debug.DrawLine(sensorStarPos, hit.point);
                        avoiding = true;
                        if (hit.normal.x < 0)
                        {
                            avoidMultiplier = -1;
                        }
                        else
                        {
                            avoidMultiplier = 1;
                        }
                    }
                }
            }
        }

        if (avoiding == true)
        {
            targetSteerAngle = maxSteerAngle * avoidMultiplier;
        }
        //print(avoidMultiplier);
    }
    private void LerpToSteerAngle()
    {
        wheelFL.steerAngle = Mathf.Lerp(wheelFL.steerAngle, targetSteerAngle, Time.deltaTime * turnSpeed);
        wheelFR.steerAngle = Mathf.Lerp(wheelFR.steerAngle, targetSteerAngle, Time.deltaTime * turnSpeed);
    }

}
