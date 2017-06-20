using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resolutions : MonoBehaviour
{
    public List<int> firstResValue = new List<int>();
    public List<int> secondResValue = new List<int>();
    public bool fullscreen;
    public Slider resolutionSlider;
    public Toggle toggle;
    public Text resolutionText;
	void Start ()
    {
        resolutionText.text = (firstResValue[Convert.ToInt32(resolutionSlider.value)].ToString() + "x" + secondResValue[Convert.ToInt32(resolutionSlider.value)].ToString());
        fullscreen = toggle.isOn;
    }
	
	void Update ()
    {
		
	}
    public void BoolChanged(bool b)
    {
        fullscreen = toggle.isOn;
        ChangeRes(Convert.ToInt32(resolutionSlider.value));
    }
    public void ValueChanged()
    {
        ChangeRes(Convert.ToInt32(resolutionSlider.value));
    }
    public void ChangeRes(int i)
    {
        resolutionText.text = (firstResValue[i].ToString() + "x" + secondResValue[i].ToString());
        Screen.SetResolution(firstResValue[i], secondResValue[i], fullscreen);
    }
}
