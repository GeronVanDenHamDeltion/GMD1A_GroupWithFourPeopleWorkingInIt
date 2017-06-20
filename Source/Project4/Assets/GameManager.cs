using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentScene;
    public int sceneNumber;
    public SaveAndLoad saveAndLoad;

    public void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            saveAndLoad.Save();
        }
        if (Input.GetButtonDown("TempLoad"))
        {
            saveAndLoad.loading();
        }
    }
    public void ChangeScene()
    {

    }
    public void Death()
    {

    }
}
