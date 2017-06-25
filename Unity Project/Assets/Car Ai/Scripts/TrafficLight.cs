using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour {

    public Material[] material;
    public Renderer rendRed;
    public Renderer rendOrange;
    public Renderer rendGreen;

	void Start ()
    {
        rendRed.enabled = true;
        rendOrange.enabled = true;
        rendRed.sharedMaterial = material[1];
        rendOrange.sharedMaterial = material[2];
        rendGreen.sharedMaterial = material[4];
    }
	

    public void Green()
    {
        rendRed.sharedMaterial = material[0];
        rendOrange.sharedMaterial = material[2];
        rendGreen.sharedMaterial = material[5];
    }
    public void Orange()
    {
        rendRed.sharedMaterial = material[0];
        rendOrange.sharedMaterial = material[3];
        rendGreen.sharedMaterial = material[4];
    }
    public void Red()
    {
        rendRed.sharedMaterial = material[1];
        rendOrange.sharedMaterial = material[2];
        rendGreen.sharedMaterial = material[4];
    }
}
