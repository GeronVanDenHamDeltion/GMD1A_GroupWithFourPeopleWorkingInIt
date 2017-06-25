using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedTrigger : MonoBehaviour
{
    public GameManager gamemanager;
    public bool ispressent;
    void Awake()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (gamemanager.progress == 2 && ispressent)
        {
            if (Input.GetButtonDown("Interact"))
            {
                gamemanager.progress++;
                gamemanager.sceneNumber = 2;
                StartCoroutine(gamemanager.ChangeScene());
            }
        }
    }
    public void OnTriggerEnter(Collider col)
    {
        ispressent = true;
    }
    public void OnTriggerExit(Collider col)
    {
        ispressent = false;
    }
}
