using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossPoint : MonoBehaviour
{
    public List<CarEngine> Cars = new List<CarEngine>();
    public List<Stop> Stops = new List<Stop>();
    public int roads;
    public int currentcount;
	
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
        if (CheckIfEmpty() == false)
        {
            setCurrentCount();
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
        for(int i = 0; i < Cars.Count; i++)
        {
            if (Cars[i] != null)
            {
                currentcount = i;
                return;
            }
        }
    }
    public IEnumerator position()
    {
        Stops[currentcount].needsToBrake = false;
        Stops[currentcount].ChangeBrake();
        yield return new WaitForSeconds(5);
        Stops[currentcount].needsToBrake = true;
        Stops[currentcount].ChangeBrake();
    }
}
