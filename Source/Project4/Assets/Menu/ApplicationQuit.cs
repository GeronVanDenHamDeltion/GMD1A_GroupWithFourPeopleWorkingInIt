using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ApplicationQuit : MonoBehaviour
{
    public GameObject ButtonNewGame;
    public GameObject ButtonLoadGame;
    public GameObject ButtonOptions;
    public GameObject ButtonExit;
    public GameObject Yes;
    public GameObject No;
    public Text textOne;
	void Start ()
    {
        Yes.SetActive(false);
        No.SetActive(false);
	}

    void Update()
    {
        if (ButtonExit.GetComponent<PaperScript>().clicked == true)
        {
            ButtonNewGame.SetActive(false);
            ButtonLoadGame.SetActive(false);
            ButtonOptions.SetActive(false);
            ButtonExit.SetActive(false);
            Yes.SetActive(true);
            No.SetActive(true);
            textOne.text = ("Sure?");
        }
        if (No.GetComponent<PaperScript>().clicked == true)
        {
            ButtonNewGame.SetActive(true);
            ButtonLoadGame.SetActive(true);
            ButtonOptions.SetActive(true);
            ButtonExit.SetActive(true);
            Yes.SetActive(false);
            No.SetActive(false);
        }
        if (Yes.GetComponent<PaperScript>().clicked == true)
        {
            Application.Quit();
        }
    }
}
