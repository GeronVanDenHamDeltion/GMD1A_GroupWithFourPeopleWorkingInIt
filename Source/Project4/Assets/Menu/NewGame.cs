using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    public PaperScript newGame;
    public GameManager gameManager;
    public Animator anim;
    void Update()
    {
        if (newGame.clicked == true)
        {
            newGame.clicked = false;
            anim.SetTrigger("NewGame");
            StartCoroutine("startNewGame");
        }
    }
    public IEnumerator startNewGame()
    {
        yield return new WaitForSeconds(2);
        gameManager.saveAndLoad.Save();
        gameManager.sceneNumber = 1;
        StartCoroutine(gameManager.ChangeScene());
        gameManager.progress++;
    }
}
