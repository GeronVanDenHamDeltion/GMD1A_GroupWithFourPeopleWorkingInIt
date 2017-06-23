using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeScene : MonoBehaviour
{
    public GameObject gameManager;
    public void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManager.GetComponent<SaveAndLoad>().FindObjects();
    }
}
