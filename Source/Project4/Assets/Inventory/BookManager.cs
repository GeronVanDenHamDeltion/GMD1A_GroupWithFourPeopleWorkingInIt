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

    public void UpdateBook()
    {
        if (currentPageNumer == pages.first)
        {
            //quests
            bookOne.sprite = pageSprites[0];
            bookTwo.sprite = pageSprites[1];
        }
        if (currentPageNumer == pages.second)
        {
            //map
            bookOne.sprite = pageSprites[2];
            bookTwo.sprite = pageSprites[3];
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
        }
    }
    public void PickedUpObject(int i)
    {

    }
}
