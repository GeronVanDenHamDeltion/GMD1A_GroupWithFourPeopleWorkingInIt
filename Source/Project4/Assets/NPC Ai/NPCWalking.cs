using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalking : MonoBehaviour
{
    public Transform path;
    public float turnSpeed;
    public float maxSteerAngle;
    public float maxBrakeTorque;
    public float maxMotorTorque;
    public float Speed;
    public float maxspeed;
    public float wayPointDistance;
    public bool stop;

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
        ApplySteer();
        Walk();
        CheckWayPointDistance();
        Braking();
	}
    private void ApplySteer()
    {
        if (avoiding == true)
        {
            return;
        }
        //Vector3 RelativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
        //float newSteer = (RelativeVector.x / RelativeVector.magnitude) * maxSteerAngle;
        //targetSteerAngle = newSteer;
    }
    private void Walk()
    {
        transform.position = Vector3.MoveTowards(transform.position, nodes[currentNode].position, Speed);
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
        if (stop == true)
        {
            Speed = 0;
        }
        else
        {
            Speed = maxspeed;
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
            Debug.DrawLine(sensorStarPos, hit.point);
            if (hit.collider.CompareTag("Terrain") == false && hit.collider.CompareTag("CarTrigger") == false)
            {
                if (hit.collider.CompareTag("SideWalk") == true)
                {
                    if (Vector3.Distance(hit.point, sensorStarPos) > sideWalkPos)
                    {
                        avoiding = true;
                        avoidMultiplier -= 1f;
                    }
                }
                else
                {
                    avoiding = true;
                    avoidMultiplier -= 1f;
                }
                
            }
        }
        
        //Front Right Angle Sensors
        if (Physics.Raycast(sensorStarPos, Quaternion.AngleAxis(frontSensorAngle, transform.up) * transform.forward, out hit, sensorLength))
        {
            Debug.DrawLine(sensorStarPos, hit.point);
            if (hit.collider.CompareTag("Terrain") == false && hit.collider.CompareTag("CarTrigger") == false)
            {
                if (hit.collider.CompareTag("SideWalk") == true)
                {
                    if (Vector3.Distance(hit.point, sensorStarPos) > sideWalkPos)
                    {
                        avoiding = true;
                        avoidMultiplier -= 0.5f;
                    }
                }
                else
                {
                    avoiding = true;
                    avoidMultiplier -= 0.5f;
                }
            }
        }

        //Front left Side Sensors
        sensorStarPos -= transform.right * sideSensorPos *2;
        if (Physics.Raycast(sensorStarPos, transform.forward, out hit, sensorLength))
        {
            Debug.DrawLine(sensorStarPos, hit.point);
            if (hit.collider.CompareTag("Terrain") == false && hit.collider.CompareTag("CarTrigger") == false)
            {
                if (hit.collider.CompareTag("SideWalk") == true)
                {
                    if (Vector3.Distance(hit.point, sensorStarPos) > sideWalkPos)
                    {
                        avoiding = true;
                        avoidMultiplier += 1f;
                    }
                }
                else
                {
                    avoiding = true;
                    avoidMultiplier += 1f;
                }
            }
        }
        
        //Front Left Angle Sensors
        if (Physics.Raycast(sensorStarPos, Quaternion.AngleAxis(-frontSensorAngle, transform.up) * transform.forward, out hit, sensorLength))
        {
            Debug.DrawLine(sensorStarPos, hit.point);
            if (hit.collider.CompareTag("Terrain") == false &&  hit.collider.CompareTag("CarTrigger") == false)
            {
                if (hit.collider.CompareTag("SideWalk") == true)
                {
                    if (Vector3.Distance(hit.point, sensorStarPos) > sideWalkPos)
                    {
                        avoiding = true;
                        avoidMultiplier += 0.5f;
                    }
                }
                else
                {
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
                Debug.DrawLine(sensorStarPos, hit.point);
                if (hit.collider.CompareTag("Terrain") == false &&  hit.collider.CompareTag("CarTrigger") == false)
                {
                    if (hit.collider.CompareTag("SideWalk") == true)
                    {
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
}
