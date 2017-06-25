using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class AwakeScene : MonoBehaviour
{
    public GameObject gameManager;
    public void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManager.GetComponent<SaveAndLoad>().FindObjects();
        gameManager.GetComponent<GameManager>().loadingscreen.enabled = false;
        if (gameManager.GetComponent<GameManager>().currentScene > 1)
        {
            DataHolder dat = Load();
            for (int i = 0; i < dat.pageAbleToSee.Count; i++)
            {
                gameManager.GetComponent<SaveAndLoad>().player.GetComponent<BookManager>().pageAbleToSee[i] = dat.pageAbleToSee[i];
            }
            
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
}
