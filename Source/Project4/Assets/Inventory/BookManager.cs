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
    public pages currentPageNumer;
    public List<Sprite> pageSprites = new List<Sprite>();
    public List<bool> pageAbleToSee = new List<bool>();
    public Sprite rippedOutPage;
    public Image bookOne;
    public Image bookTwo;
    public Button forwardButton;
    public Button backwardButton;
    public GameObject inventory;

    public void Start()
    {
        inventory.SetActive(false);
    }
    public void UpdateBook()
    {
        if (currentPageNumer == pages.first)
        {
            //quests
            bookOne.sprite = pageSprites[0];
            bookTwo.sprite = pageSprites[1];
            backwardButton.gameObject.SetActive(false);
        }
        if (currentPageNumer == pages.second)
        {
            //map
            bookOne.sprite = pageSprites[2];
            bookTwo.sprite = pageSprites[3];
            backwardButton.gameObject.SetActive(true);
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
                bookOne.sprite = pageSprites[5];
            }
            else
            {
                bookOne.sprite = rippedOutPage;
            }
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
                bookOne.sprite = pageSprites[7];
            }
            else
            {
                bookOne.sprite = rippedOutPage;
            }
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
                bookOne.sprite = pageSprites[9];
            }
            else
            {
                bookOne.sprite = rippedOutPage;
            }
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
            currentPageNumer = pages.second;
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
            currentPageNumer = pages.second;
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
    public void Update()
    {
        if (Input.GetButtonDown("Inventory") && inventory.activeInHierarchy == false)
        {
            inventory.SetActive(true);
            currentPageNumer = pages.first;
            UpdateBook();
        }
        else if ((Input.GetButtonDown("Inventory") || Input.GetButtonDown("Cancel") )&& inventory.activeInHierarchy == true)
        {
            inventory.SetActive(false);
        }
    }
}
