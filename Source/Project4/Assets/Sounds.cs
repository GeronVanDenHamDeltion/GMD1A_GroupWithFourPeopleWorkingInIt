using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public List<AudioSource> audios = new List<AudioSource>();
    public void Awake()
    {
        changeVolumes();
    }
    public ResSave Load()
    {
        var serializer = new XmlSerializer(typeof(ResSave));
        using (var stream = new FileStream(Application.dataPath + "/UserSettings.xml", FileMode.Open))
        {
            return serializer.Deserialize(stream) as ResSave;
        }
    }
    public void changeVolumes()
    {
        for (int i = 0; i < audios.Count; i++)
        {
            ResSave ressave = Load();
            audios[i].volume = ressave.volume;
        }
    }
}
