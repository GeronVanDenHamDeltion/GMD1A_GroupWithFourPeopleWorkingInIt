using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedTrigger : MonoBehaviour
{
    public GameManager gamemanager;
    public Text text;
    public bool ispressent;
    public bool textbool;
    void Awake()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (gamemanager.progress == 2 && ispressent)
        {
            text.text = ("Press Enter to go to sleep");
            textbool = true;
            if (Input.GetButtonDown("Interact"))
            {
                text.text = ("");
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
        if (textbool == true)
        {
            text.text = ("");
        }
        ispressent = false;
    }
}
