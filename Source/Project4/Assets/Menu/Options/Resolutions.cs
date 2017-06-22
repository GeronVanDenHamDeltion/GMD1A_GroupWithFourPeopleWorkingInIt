using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Resolutions : MonoBehaviour
{
    public List<int> firstResValue = new List<int>();
    public List<int> secondResValue = new List<int>();
    public List<string> textureQualNames = new List<string>();
    public bool fullscreen;
    public Slider resolutionSlider;
    public Slider TextureSlider;
    public Toggle toggle;
    public Text resolutionText;
    public Text textureText;
    public ResSave SaveFile;
    public ResSave FirstStart;
    void Start ()
    {
        if (File.Exists(Application.dataPath + "/UserSettings.xml"))
        {
            loading();
        }else
        {
            SaveFile = FirstStart;
        }
        resolutionSlider.value = SaveFile.Resolution;
        TextureSlider.value = SaveFile.TextureQual;
        toggle.isOn = SaveFile.Fullscreen;
        Screen.SetResolution(firstResValue[Convert.ToInt32(SaveFile.Resolution)], secondResValue[Convert.ToInt32(SaveFile.Resolution)], SaveFile.Fullscreen);
        QualitySettings.SetQualityLevel(Convert.ToInt32(SaveFile.TextureQual));
        resolutionText.text = (firstResValue[Convert.ToInt32(SaveFile.Resolution)].ToString() + "x" + secondResValue[Convert.ToInt32(SaveFile.Resolution)].ToString());
        textureText.text = textureQualNames[Convert.ToInt32(SaveFile.TextureQual)];
    }
	
    public void ChangeValues()
    {
        Save();
        Screen.SetResolution(firstResValue[Convert.ToInt32(resolutionSlider.value)], secondResValue[Convert.ToInt32(resolutionSlider.value)], toggle.isOn);
        QualitySettings.SetQualityLevel(Convert.ToInt32(TextureSlider.value));
    }

    public void ChangeResText()
    {
        resolutionText.text = (firstResValue[Convert.ToInt32(resolutionSlider.value)].ToString() + "x" + secondResValue[Convert.ToInt32(resolutionSlider.value)].ToString());
    }
    public void ChangeTexText()
    {
        textureText.text = textureQualNames[Convert.ToInt32(TextureSlider.value)];
    }
    public void Save()
    {
        SaveFile.Resolution = resolutionSlider.value;
        SaveFile.TextureQual = TextureSlider.value;
        SaveFile.Fullscreen = toggle.isOn;
        print("savingRes");
        var serializer = new XmlSerializer(typeof(ResSave));
        using (var stream = new FileStream(Application.dataPath + "/UserSettings.xml", FileMode.Create))
        {
            serializer.Serialize(stream, SaveFile);
        }
    }
    public ResSave Load()
    {
        var serializer = new XmlSerializer(typeof(ResSave));
        using (var stream = new FileStream(Application.dataPath + "/UserSettings.xml", FileMode.Open))
        {
            return serializer.Deserialize(stream) as ResSave;
        }
    }
    public void loading()
    {
        print("loading");
        SaveFile = Load();
        resolutionSlider.value = SaveFile.Resolution;
        TextureSlider.value = SaveFile.TextureQual;
        toggle.isOn = SaveFile.Fullscreen;
    }
}
