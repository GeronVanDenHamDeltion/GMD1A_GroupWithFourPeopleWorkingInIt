using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentScene;
    public int sceneNumber;
    public SaveAndLoad saveAndLoad;
    public int progress;
    public bool menu;
    //1. 1st entry
    //2. 2th entry
    //3. 3th entry
    //4. 4th entry

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
        if (progress > 0 && menu == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }else
        {
            Cursor.lockState = CursorLockMode.None;

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
            //SceneManager.sceneLoaded += LevelLoaded;
        }
        if (sceneNumber == 2)
        {
            SceneManager.LoadScene("World");
            //SceneManager.sceneLoaded += LevelLoaded;
        }
    }

    void LevelLoaded(Scene scene, LoadSceneMode mode)
    {
    }
}
