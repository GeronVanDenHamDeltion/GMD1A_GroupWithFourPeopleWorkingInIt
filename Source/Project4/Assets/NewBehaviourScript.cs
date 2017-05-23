using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    private bool done;
	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Test(4));
        if (done == true)
        {
            print("function");
            done = false;
        }       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private IEnumerator Test(int i )
    {
        yield return new WaitForSeconds(i);
        done = true;
    }
}
