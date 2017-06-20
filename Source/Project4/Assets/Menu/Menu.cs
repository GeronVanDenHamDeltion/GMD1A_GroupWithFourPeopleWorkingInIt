using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public Text text;
    public GameObject title;
    public GameObject menuText;
    public Camera menuCamera;
    public GameObject menuLetter1;
    public GameObject menuLetter2;
    public GameObject menuLetter3;
    public float alpha;
    public float fov;


    void Start()
    {
        
        fov = 160;
        alpha = 0;
    }

    void FixedUpdate()
    {
        if (fov >= 50 )
        {
            fov = fov*0.990f;
            title.GetComponent<CanvasRenderer>().SetAlpha(alpha);
            menuText.GetComponent<CanvasRenderer>().SetAlpha(alpha);
        }
        else
        {
            title.GetComponent<CanvasRenderer>().SetAlpha(alpha);
            menuText.GetComponent<CanvasRenderer>().SetAlpha(alpha);
            alpha =  alpha + 0.005f;
        }
        menuCamera.fieldOfView = fov;
    }
    public void SetUIText(string textToSet)
    {
        text.text = textToSet;
        
    }


}
