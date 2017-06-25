using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBrake : MonoBehaviour {
    public CarEngine thisEngine;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Car") || other.CompareTag("NPC") || other.CompareTag("Player"))
        {
            thisEngine.brake = true;
            thisEngine.stillbrake = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        StartCoroutine(waitASec());
    }
    public IEnumerator waitASec()
    {
        yield return new WaitForSeconds((Random.Range(0.1f, 2f)));
        thisEngine.brake = false;
        thisEngine.stillbrake = false;
    }
}
