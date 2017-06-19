﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperScript : MonoBehaviour {

    public bool selected;
    public Text text;

    public void OnMouseOver()
    {
        selected = true;
        
        if(Input.GetButtonDown("Fire1"))
        {
            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, new Vector3(3, 3, 3), 22 * Time.deltaTime);
        }
    }

    public void OnMouseExit()
    {
        selected = false;
    }

    void Update()
    {
        if (selected)
        {
            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, new Vector3(2, 2, 2), 10 * Time.deltaTime);
        }
        else
        {
            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, new Vector3(1, 1, 1), 10 * Time.deltaTime);
            text.text = ("");
        }
    }





}