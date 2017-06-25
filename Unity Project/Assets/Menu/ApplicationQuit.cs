using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ApplicationQuit : MonoBehaviour
{
    public Animator anim;
    public PaperScript ButtonExit;
    public PaperScript Yes;
    public PaperScript No;
    public Text textOne;

    void Update()
    {
        if (ButtonExit.clicked == true)
        {
            anim.SetBool("Exit", true);
            ButtonExit.clicked = false;
            StartCoroutine(waitforexit());
        }
        if (No.clicked == true)
        {
            anim.SetBool("Exit", false);
            textOne.text = ("");
            No.clicked = false;
        }
        if (Yes.clicked == true)
        {
            Yes.clicked = false;
            Application.Quit();
        }
    } 
    public IEnumerator waitforexit()
    {
        yield return new WaitForSeconds(1);
        textOne.text = ("Sure?");
    }
}
