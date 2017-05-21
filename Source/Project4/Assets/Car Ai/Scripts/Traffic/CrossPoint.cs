using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossPoint : MonoBehaviour
{
    public List<CarEngine> Cars = new List<CarEngine>();
    public List<Stop> Stops = new List<Stop>();
    public List<TrafficLight> trafficLights = new List<TrafficLight>();
    public int roads;
    public int currentcount;
    public int waitTime;
    public bool empty;
    public bool runningRoutine;
	
    public void FillList(int i, CarEngine car)
    {
        Cars[i] = car;
    }
    public void EmptyList(int i)
    {
        Cars[i] = null;
    }
    void Update()
    {
        empty = CheckIfEmpty();
        if (CheckIfEmpty() == false && runningRoutine == false)
        {
            setCurrentCount();
            runningRoutine = true;
            StartCoroutine(position());
        }
    }
    public bool CheckIfEmpty()
    {
        int nulls = 0;
        for (int i = 0; i < Cars.Count; i++)
        {
            if (Cars[i] == null)
            {
                nulls++;
            }
        }
        if (nulls > Cars.Count-1)
        {
            return true;
        }
        else return false;
    }
    public void setCurrentCount()
    {
        currentcount++;
        if (currentcount > Stops.Count-1)
        {
            currentcount = 0;
        }
    }
    public IEnumerator position()
    {
        print(currentcount);
        trafficLights[currentcount].Green();
        Stops[currentcount].needsToBrake = false;
        Stops[currentcount].ChangeBrake();
        yield return new WaitForSeconds(waitTime);
        trafficLights[currentcount].Orange();
        Stops[currentcount].needsToBrake = true;
        Stops[currentcount].ChangeBrake();
        yield return new WaitForSeconds(5);
        trafficLights[currentcount].Red();
        runningRoutine = false;
    }
}
