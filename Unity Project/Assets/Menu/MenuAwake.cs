using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAwake : MonoBehaviour
{
    public GameObject gamemanager;
	void Start()
    {
        gamemanager.GetComponent<GameManager>().loadingscreen.enabled = false;
    }
	
}
