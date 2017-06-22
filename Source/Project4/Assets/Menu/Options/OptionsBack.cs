using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsBack : MonoBehaviour
{
    public bool selected;
    public Animator anim;
    public Canvas startScreenCanvas;
    public Canvas OptionsCanvanScreenSpace;
    public float scale;
    public float startscale;
    public float clickscale;
    public void OnMouseOver()
    {
        selected = true;

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("Options", false);
            startScreenCanvas.enabled = true;
            OptionsCanvanScreenSpace.enabled = false;
            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, new Vector3(clickscale,clickscale,clickscale), 22 * Time.deltaTime);
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
            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, new Vector3(scale,scale,scale), 10 * Time.deltaTime);
        }
        else
        {
            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, new Vector3(startscale, startscale, startscale), 10 * Time.deltaTime);

        }
    }
}
