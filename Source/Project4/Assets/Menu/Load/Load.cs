using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
    public GameObject loadbutton;
    public PaperScript options;
    public GameManager gameManager;
    public Animator anim;
    public Sprite room;
    public Sprite world;
	void Awake ()
    {
        if (File.Exists(Application.dataPath + "/SaveFileOne.xml"))
        {
            loadbutton.SetActive(true);
            DataHolder dat = Loading();
            if (dat.currentScene == 1 || dat.currentScene == 1)
            {
                loadbutton.GetComponent<Image>().sprite = room;
            }
            else if (dat.currentScene == 2)
            {
                loadbutton.GetComponent<Image>().sprite = world;
            }
            else
            {
                loadbutton.SetActive(false);
            }
        }
        else
        {
            loadbutton.SetActive(false);
        }
    }
    public DataHolder Loading()
    {
        var serializer = new XmlSerializer(typeof(DataHolder));
        using (var stream = new FileStream(Application.dataPath + "/SaveFileOne.xml", FileMode.Open))
        {
            return serializer.Deserialize(stream) as DataHolder;
        }
    }
    void Update ()
    {
	    if (options.clicked == true)
        {
            anim.SetBool("Load", true);
            options.clicked = false;
        }	
	}
    public void Back()
    {
        anim.SetBool("Load", false);
    }
    public void StartLoad()
    {
        anim.SetTrigger("LoadGame");
        StartCoroutine(startLoadGame());
    }
    public IEnumerator startLoadGame()
    {
        yield return new WaitForSeconds(2);
        gameManager.saveAndLoad.loading();
        StartCoroutine(gameManager.ChangeScene());
    }
}
