using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserSettings : MonoBehaviour
{
    public Animator anim;
    public PaperScript OptionsScript;
    public Canvas startScreenCanvas;
    public Canvas OptionsCanvanScreenSpace;
	void Start ()
    {
        OptionsCanvanScreenSpace.enabled = false;
	}
	
	void Update ()
    {
		if (OptionsScript.clicked == true)
        {
            Options();
            OptionsScript.clicked = false;
            startScreenCanvas.enabled = false;
            OptionsCanvanScreenSpace.enabled = true;
        }
	}
    public void Options()
    {
        anim.SetBool("Options", true);
    }
}
