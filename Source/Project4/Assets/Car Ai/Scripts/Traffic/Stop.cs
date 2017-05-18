using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    public bool needsToBrake;
    public CrossPoint thisCrossPoint;
    public CarEngine thisEngine;
    public int roadnumber;
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
        if (other.CompareTag("Car") == true)
        {
            thisEngine = other.GetComponent<CarParant>().thisCarEngine;
            thisCrossPoint.FillList(roadnumber-1, thisEngine);
        }
        
    }
    void onTriggerStay(Collider other)
    {
        if (other.CompareTag("Car") == true)
        {
            if (needsToBrake == true)
            {
                other.GetComponent<CarParant>().thisCarEngine.brake = true;
                other.GetComponent<CarParant>().thisCarEngine.stillbrake = true;
            }
            if (needsToBrake == false)
            {
                other.GetComponent<CarParant>().thisCarEngine.brake = false;
                other.GetComponent<CarParant>().thisCarEngine.stillbrake = false;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car") == true)
        {
            thisEngine = null;
            thisCrossPoint.EmptyList(roadnumber-1);
        }
    }
}
