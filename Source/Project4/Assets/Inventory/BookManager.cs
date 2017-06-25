using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookManager : MonoBehaviour
{
    public enum pages
    {
        first,
        second,
        third,
        fourth,
        fifth
    }
    public Canvas bookCanvas;
    public Canvas menuCanvas;
    public pages currentPageNumer;
    public List<Sprite> entryPages = new List<Sprite>();
    public List<Sprite> pageSprites = new List<Sprite>();
    public List<bool> pageAbleToSee = new List<bool>();
    public Sprite rippedOutPage;
    public Image bookOne;
    public Image bookTwo;
    public Button forwardButton;
    public Button backwardButton;
    public GameObject inventory;
    public GameManager gamemanager;
    public bool wait;
    public bool waittwo;

    public void Awake()
    {
        bookCanvas.enabled = false;
        menuCanvas.enabled = false;
        gamemanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    public void Start()
    {
        inventory.SetActive(false);
    }
    public void UpdateBook()
    {
        if (currentPageNumer == pages.first)
        {
            //quests
            if (gamemanager.progress == 1)
            {
                bookOne.sprite = entryPages[0];
                bookTwo.sprite = rippedOutPage;
            }
            if (gamemanager.progress == 2)
            {
                bookOne.sprite = entryPages[1];
                bookTwo.sprite = rippedOutPage;
            }
            if (gamemanager.progress == 3)
            {
                bookOne.sprite = entryPages[2];
                bookTwo.sprite = entryPages[3];
            }
            if (gamemanager.progress == 4)
            {
                bookOne.sprite = entryPages[2];
                bookTwo.sprite = entryPages[4];
            }
            backwardButton.gameObject.SetActive(false);
            forwardButton.gameObject.SetActive(true);
        }
        if (currentPageNumer == pages.second)
        {
            //map
            bookOne.sprite = pageSprites[2];
            bookTwo.sprite = pageSprites[3];
            backwardButton.gameObject.SetActive(true);
            forwardButton.gameObject.SetActive(true);

        }
        if (currentPageNumer == pages.third)
        {
            //first memo's
            if (pageAbleToSee[0] == true)
            {
                bookOne.sprite = pageSprites[4];
            }
            else
            {
                bookOne.sprite = rippedOutPage;
            }
            if (pageAbleToSee[1] == true)
            {
                bookTwo.sprite = pageSprites[5];
            }
            else
            {
                bookTwo.sprite = rippedOutPage;
            }
            backwardButton.gameObject.SetActive(true);
            forwardButton.gameObject.SetActive(true);
        }
        if (currentPageNumer == pages.fourth)
        {
            //second memo's
            if (pageAbleToSee[2] == true)
            {
                bookOne.sprite = pageSprites[6];
            }
            else
            {
                bookOne.sprite = rippedOutPage;
            }
            if (pageAbleToSee[3] == true)
            {
                bookTwo.sprite = pageSprites[7];
            }
            else
            {
                bookTwo.sprite = rippedOutPage;
            }
            backwardButton.gameObject.SetActive(true);
            forwardButton.gameObject.SetActive(true);
        }
        if (currentPageNumer == pages.fifth)
        {
            //second memo's
            if (pageAbleToSee[4] == true)
            {
                bookOne.sprite = pageSprites[8];
            }
            else
            {
                bookOne.sprite = rippedOutPage;
            }
            if (pageAbleToSee[5] == true)
            {
                bookTwo.sprite = pageSprites[9];
            }
            else
            {
                bookTwo.sprite = rippedOutPage;
            }
            backwardButton.gameObject.SetActive(true);
            forwardButton.gameObject.SetActive(false);
        }
    }
    public void PickedUpObject(int i)
    {
        pageAbleToSee[i - 1] = true;
    }
    public void updateBook(bool forward)
    {
        if (currentPageNumer == pages.first && forward == false)
        {
            currentPageNumer = pages.first;
        } 
        else if (currentPageNumer == pages.first && forward == true)
        {
            if (gamemanager.progress > 2)
            {
                currentPageNumer = pages.second;
            }
            if (gamemanager.progress <= 2)
            {
                currentPageNumer = pages.third;
            }
        }
        else if (currentPageNumer == pages.second && forward == false)
        {
            currentPageNumer = pages.first;
        }
        else if (currentPageNumer == pages.second && forward == true)
        {
            currentPageNumer = pages.third;
        }
        else if (currentPageNumer == pages.third && forward == false)
        {
            if (gamemanager.progress > 2)
            {
                currentPageNumer = pages.second;
            }
            if (gamemanager.progress <= 2)
            {
                currentPageNumer = pages.first;
            }
        }
        else if (currentPageNumer == pages.third && forward == true)
        {
            currentPageNumer = pages.fourth;
        }
        else if (currentPageNumer == pages.fourth && forward == false)
        {
            currentPageNumer = pages.third;
        }
        else if (currentPageNumer == pages.fourth && forward == true)
        {
            currentPageNumer = pages.fifth;
        }
        else if (currentPageNumer == pages.fifth && forward == false)
        {
            currentPageNumer = pages.fourth;
        }
        else if (currentPageNumer == pages.fifth && forward == true)
        {
            currentPageNumer = pages.fifth;
        }
        backwardButton.enabled = true;
        forwardButton.enabled = true;
        UpdateBook();
    }
    public void save()
    {
        gamemanager.saveAndLoad.Save();
    }
    public void Exit()
    {
        gamemanager.sceneNumber = 0;
        StartCoroutine(gamemanager.ChangeScene());
        
    }
    public void Update()
    {
        if (Input.GetButtonDown("Inventory") && inventory.activeInHierarchy == false)
        {
            bookCanvas.enabled = true;
            inventory.SetActive(true);
            currentPageNumer = pages.first;
            UpdateBook();
            gamemanager.menu = true;
            CamMouseLook[] cam = this.GetComponentsInChildren<CamMouseLook>();
            for (int i = 0; i < cam.Length; i++)
            {
                cam[i].enabled = false;
            }
        }
        else if ((Input.GetButtonDown("Inventory") || Input.GetButtonDown("Cancel")) && inventory.activeInHierarchy == true && bookCanvas.isActiveAndEnabled == true)
        {
            bookCanvas.enabled = false;
            inventory.SetActive(false);
            gamemanager.menu = false;
            CamMouseLook[] cam = this.GetComponentsInChildren<CamMouseLook>();
            for (int i = 0; i < cam.Length; i++)
            {
                cam[i].enabled = true;
            }
        }
        if (Input.GetButtonDown("Cancel") && inventory.activeInHierarchy == false)
        {
            menuCanvas.enabled = true;
            inventory.SetActive(true);
            gamemanager.menu = true;
            CamMouseLook[] cam = this.GetComponentsInChildren<CamMouseLook>();
            for (int i = 0; i < cam.Length; i++)
            {
                cam[i].enabled = false;
            }
        }
        else if (Input.GetButtonDown("Cancel") && inventory.activeInHierarchy == true && menuCanvas.enabled == true)
        {
            menuCanvas.enabled = false;
            inventory.SetActive(false);
            gamemanager.menu = false;
            CamMouseLook[] cam = this.GetComponentsInChildren<CamMouseLook>();
            for (int i = 0; i < cam.Length; i++)
            {
                cam[i].enabled = true;
            }
        }
        if (pageAbleToSee[0] && pageAbleToSee[1] && pageAbleToSee[2] && wait == false)
        {
            if (gamemanager.currentScene == 1)
            {
                wait = true;
                gamemanager.progress++;
            }
            else
            {
                wait = true;
            }
        }
    }
}
