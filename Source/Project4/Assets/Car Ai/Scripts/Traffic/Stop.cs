using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    public bool needsToBrake;
    public CrossPoint thisCrossPoint;
    public CarEngine thisEngine;
    public int roadnumber;
    public CarEngine crossing;
    void Start()
    {
        needsToBrake = true;
    }
	
	void Update ()
    {
	}
    void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        if (other.CompareTag("Car") == true && crossing == false)
        {
            thisEngine = other.GetComponent<CarParant>().thisCarEngine;
            thisCrossPoint.FillList(roadnumber-1, thisEngine);
            if (needsToBrake == true)
            {
                thisEngine.brake = true;
                thisEngine.stillbrake = true;
            }
            if (needsToBrake == false)
            {
                thisEngine.brake = false;
                thisEngine.stillbrake = false;
                
            }
        }
    }
    public void ChangeBrake()
    {
        if (needsToBrake == true)
        {
            thisEngine.brake = true;
            thisEngine.stillbrake = true;
        }
        if (needsToBrake == false)
        {
            thisEngine.brake = false;
            thisEngine.stillbrake = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car") == true)
        {
            thisEngine = null;
            thisCrossPoint.EmptyList(roadnumber-1);
            if (thisEngine.crossing == true)
            {
                thisEngine.crossing = false;
            }
            if (thisEngine.crossing == false)
            {
                thisEngine.crossing = true;
            }
        }
    }
}
