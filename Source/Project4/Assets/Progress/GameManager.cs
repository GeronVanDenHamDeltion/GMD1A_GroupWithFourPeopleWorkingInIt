﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentScene;
    public int sceneNumber;
    public SaveAndLoad saveAndLoad;
    public int progress;
    public bool menu;
    public Image loadingscreen;
    //1. 1st entry
    //2. 2th entry
    //3. 3th entry
    //4. 4th entry

    public void Awake()
    {
        loadingscreen.enabled = false;
    }
    public void Update()
    {
        if (progress > 0 && menu == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }else
        {
            Cursor.lockState = CursorLockMode.None;

        }
    }
    public IEnumerator ChangeScene()
    {

        print("Change");
        loadingscreen.enabled = true;
        yield return new WaitForEndOfFrame();
        DontDestroyOnLoad(transform.gameObject);
        if (sceneNumber == 0)
        {
            currentScene = 0;
            SceneManager.LoadScene("MainMenu");
        }
        if (sceneNumber == 1)
        {
            currentScene = 1;
            SceneManager.LoadScene("Room");
            //SceneManager.sceneLoaded += LevelLoaded;
        }
        if (sceneNumber == 2)
        {
            currentScene = 2;
            SceneManager.LoadScene("World");
            //SceneManager.sceneLoaded += LevelLoaded;
        }
    }

    void LevelLoaded(Scene scene, LoadSceneMode mode)
    {
    }
}
