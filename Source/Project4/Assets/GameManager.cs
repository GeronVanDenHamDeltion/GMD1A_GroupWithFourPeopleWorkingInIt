using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentScene;
    public int sceneNumber;
    public GameObject player;
    //public SaveAndLoad saveAndLoad;

    public void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            //saveAndLoad.Save();
        }
        if (Input.GetButtonDown("TempLoad"))
        {
            //saveAndLoad.loading();
        }
    }
    public void ChangeScene()
    {
        print("Change");
        DontDestroyOnLoad(transform.gameObject);
        if (sceneNumber == 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (sceneNumber == 1)
        {
            SceneManager.LoadScene("Room");
        }
        if (sceneNumber == 2)
        {
            SceneManager.LoadScene("World");
        }
    }
}
