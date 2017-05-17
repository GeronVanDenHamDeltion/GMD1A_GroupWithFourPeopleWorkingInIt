using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpeed : MonoBehaviour
{
    public float maxSpeed;
    public float brakeOfset;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            other.GetComponent<CarParant>().thisCarEngine.maxSpeed = maxSpeed;
            if (other.GetComponent<CarParant>().thisCarEngine.currentSpeed > maxSpeed + brakeOfset)
            {
                other.GetComponent<CarParant>().thisCarEngine.brake = true;
            }
        } else return;
    }
}
