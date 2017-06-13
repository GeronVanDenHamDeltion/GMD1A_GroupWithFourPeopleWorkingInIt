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
        Fourth
    }
    public pages currentPageNumer;
    public Image pageOne;
    public Image pageTwo;
    public Image pageThree;
    public Image pageFourNoteOne;
    public Image pageFive;
    public Image pageSixNoteTwo;
    public Image pageSeven;
    public Image pageEightNoteThree;
    public Image rippedOutPage;
    public bool noteOnePickupUp;
    public bool noteTwoPickupUp;
    public bool noteThreePickupUp;

    public void enableNote(int i)
    {
        if (i == 1)
        {
            noteOnePickupUp = true;
        }
        if (i == 2)
        {
            noteTwoPickupUp = true;
        }
        if (i == 3)
        {
            noteThreePickupUp = true;
        }
    }
    public void nextPage()
    {
        if (currentPageNumer == pages.first)
        {

        }
    }
    public void previousPage()
    {
        if (currentPageNumer == pages.first)
        {
            return;
        }
    }

}
