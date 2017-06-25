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
        ChangeBrake();
	}
    void OnTriggerEnter(Collider other)
    {
        //print(other.gameObject.name);
        if (other.CompareTag("Car") == true && other.GetComponent<CarParant>().thisCarEngine.crossing == false)
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
        if (thisEngine != null)
        {
            if (thisEngine.crossing == false)
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
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car") == true)
        {
            CarEngine engine = other.GetComponent<CarParant>().thisCarEngine;
            if (engine.crossing == true)
            {
                engine.crossing = false;
            } else if (engine.crossing == false)
            {
                engine.crossing = true;
                thisCrossPoint.EmptyList(roadnumber - 1);
                thisEngine = null;
            }
        }
    }
}
