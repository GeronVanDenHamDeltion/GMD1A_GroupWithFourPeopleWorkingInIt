using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
    public GameObject loadbutton;
	void Awake ()
    {
        if (File.Exists(Application.dataPath + "/SaveFileOne.xml"))
        {
            loadbutton.SetActive(true);

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
		
	}
}
