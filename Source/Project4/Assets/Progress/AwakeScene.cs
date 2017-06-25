using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeScene : MonoBehaviour
{
    public GameObject gameManager;
    public void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        if (gameManager.GetComponent<SaveAndLoad>().player != null)
        {
            gameManager.GetComponent<SaveAndLoad>().player.SetActive(true);
        }
        gameManager.GetComponent<SaveAndLoad>().FindObjects();
        gameManager.GetComponent<GameManager>().loadingscreen.enabled = false;
    }
}
