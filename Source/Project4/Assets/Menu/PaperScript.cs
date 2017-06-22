using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperScript : MonoBehaviour {

    public bool selected;
    public Text text;
    public string paperText;
    public Menu menuScript;
    public bool clicked;

    public void OnMouseOver()
    {
        text.text = paperText;
        selected = true;
        
        if(Input.GetButtonDown("Fire1"))
        {
            clicked = true;
            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, new Vector3(3, 3, 3), 22 * Time.deltaTime);
        }
    }

    public void OnMouseExit()
    {
        selected = false;
        text.text = ("");
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
            
        }
    }





}
