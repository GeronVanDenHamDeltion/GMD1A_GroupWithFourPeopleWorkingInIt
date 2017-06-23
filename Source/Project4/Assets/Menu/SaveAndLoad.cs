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

    public void FindObjects()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bookManager = GameObject.FindGameObjectWithTag("Player").GetComponent<BookManager>();
    }
    public void Save()
    {
        print("saving");
        dataHolder = new DataHolder();
        if (player != null)
        {
            dataHolder.playerlocation = player.transform.position;
        }
        for (int i = 0; i < 6; i++)
        {
            dataHolder.pageAbleToSee.Add(false);
        }
        if (bookManager != null)
        {
            for (int i = 0; i < dataHolder.pageAbleToSee.Count; i++)
            {
                dataHolder.pageAbleToSee[i] = bookManager.pageAbleToSee[i];
            }
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
        if (player != null)
        {
            player.transform.position = dataHolder.playerlocation;
        }
        if (bookManager != null)
        {
            for (int i = 0; i < dataHolder.pageAbleToSee.Count; i++)
            {
                bookManager.pageAbleToSee[i] = dataHolder.pageAbleToSee[i];
            }
        }
        gameManager.currentScene = dataHolder.currentScene;
        if (gameManager.currentScene != gameManager.sceneNumber)
        {
        gameManager.ChangeScene();
        }

    }
}
