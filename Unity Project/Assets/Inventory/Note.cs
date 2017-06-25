using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class Note : MonoBehaviour
{
    public int noteNumber;
    public void Awake()
    {
        DataHolder dat = Load();
        if (dat.pageAbleToSee[noteNumber] == true)
        {
            Destroy(gameObject);
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
