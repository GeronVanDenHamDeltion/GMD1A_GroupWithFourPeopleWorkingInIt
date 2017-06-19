﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    public DataHolder dataHolder;
    public GameObject player;
    public BookManager bookManager;
    public GameManager gameManager;

    public void Save()
    {
        print("saving");
        dataHolder = new DataHolder();
        dataHolder.playerlocation = player.transform.position;
        dataHolder.playerRotation = player.GetComponentInChildren<Camera>().transform.rotation.eulerAngles;
        for (int i = 0; i < 6; i++)
        {
            dataHolder.pageAbleToSee.Add(false);
        }
        for (int i = 0;  i < dataHolder.pageAbleToSee.Count; i++)
        {
            dataHolder.pageAbleToSee[i] = bookManager.pageAbleToSee[i];
        }
        dataHolder.currentScene = gameManager.currentScene;
        var serializer = new XmlSerializer(typeof(DataHolder));
        using (var stream = new FileStream(Application.dataPath + "/SaveFileOne.xml", FileMode.Create))
        {
            serializer.Serialize(stream, dataHolder);
        }
    }

    public DataHolder Load()
    {
        var serializer = new XmlSerializer(typeof(DataHolder));
        using (var stream = new FileStream(Application.dataPath + "/SaveFileOne.xml", FileMode.Open))
        {
            return serializer.Deserialize(stream) as DataHolder;
        }
    }
    public void loading()
    {
        print("loading");
        dataHolder = Load();
        player.transform.position = dataHolder.playerlocation;
            //CamMouseLook[] camArray = player.GetComponentsInChildren<CamMouseLook>();
            //foreach(CamMouseLook cml in camArray)
            //{
            //    cml.enabled = false;
            //}
            //Camera[] cam = player.GetComponentsInChildren<Camera>();
            //foreach(Camera camera in cam)
            //{
            //    camera.transform.rotation = Quaternion.Euler(dataHolder.playerRotation);
            //}
            //player.GetComponentInChildren<Camera>().transform.rotation = Quaternion.Euler(dataHolder.playerRotation);
            //foreach (CamMouseLook cml in camArray)
            //{
            //    cml.enabled = true;
            //}
        for (int i = 0; i < dataHolder.pageAbleToSee.Count; i++)
        {
            bookManager.pageAbleToSee[i] = dataHolder.pageAbleToSee[i];
        }
        gameManager.currentScene = dataHolder.currentScene;
        if (gameManager.currentScene != gameManager.sceneNumber)
        {
        gameManager.ChangeScene();
        }

    }
}
