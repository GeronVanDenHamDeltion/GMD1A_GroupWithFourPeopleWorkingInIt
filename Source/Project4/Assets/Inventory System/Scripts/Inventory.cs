using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<InventoryPlace> InventoryItems = new List<InventoryPlace>();
    public List<Image> InventorySlots = new List<Image>();

    [Header("ItemStats")]
    public Text itemName;
    public Image BackgroundImage;
    public Image itemSprite;
    public Text amount;
    public Text despriction;

    private int currentPlace;
    
    void Awake()
    {
        DisplayNothing();
        for (int i  = 0; i < InventorySlots.Count; i++)
        {
            InventorySlots[i].enabled = false;
            InventorySlots[i].GetComponent<SlotInfo>().amount.text = ("");
        }
    }
    public void InventoryChange(Item itemInfo)
    {
        if (ItemAlreadyInInventory(itemInfo.itemID) == true)
        {
            InventoryItems[currentPlace].amount++;
            InventorySlots[currentPlace].sprite = InventoryItems[currentPlace].thisItem.sprite;
            InventorySlots[currentPlace].GetComponent<SlotInfo>().amount.text = (InventoryItems[currentPlace].amount.ToString() + "x");
            InventoryItems[currentPlace].spriteOfThisItem = itemInfo.sprite;
        }
        else
        {
            Emptyplace();
            InventoryItems[currentPlace].thisItem = itemInfo;
            InventoryItems[currentPlace].amount++;
            InventoryItems[currentPlace].isFilled = true;
            InventorySlots[currentPlace].sprite = InventoryItems[currentPlace].thisItem.sprite;
            InventorySlots[currentPlace].enabled = true;
            InventorySlots[currentPlace].GetComponent<SlotInfo>().amount.text = (InventoryItems[currentPlace].amount.ToString() + "x");
            InventoryItems[currentPlace].spriteOfThisItem = itemInfo.sprite;
        }
        currentPlace = 0;
    }
    public void ClearPlace(int i)
    {
        InventoryItems[i] = new InventoryPlace();
        InventoryItems[i].Inventoryslot = InventorySlots[i];
        InventoryItems[i].Inventoryslot.enabled = false;
        InventoryItems[i].Inventoryslot.GetComponentInChildren<Text>().text = ("");
    }
    public void InventoryChangeTwo(int i, InventoryPlace inventoryPlace)
    {
        InventoryItems[i] = inventoryPlace;
        InventoryItems[i].thisItem.sprite = inventoryPlace.thisItem.sprite;
        InventoryItems[i].Inventoryslot = InventorySlots[i];
        InventoryItems[i].Inventoryslot.GetComponent<SlotInfo>().amount.text = (InventoryItems[i].amount.ToString() + "x");
        InventoryItems[i].Inventoryslot.enabled = true;
    }
    public void DisplayItemStats(int i)
    {
        if (InventoryItems[i - 1].isFilled == true)
        {
            itemName.text = InventoryItems[i-1].thisItem.Name;
            BackgroundImage.enabled = true;
            itemSprite.sprite = InventoryItems[i - 1].thisItem.sprite;
            itemSprite.enabled = true;
            amount.text = (("Amount: ") + InventoryItems[i - 1].amount.ToString());
            despriction.text = InventoryItems[i - 1].thisItem.description;
        }
    }
    public void DisplayNothing()
    {
        itemName.text = ("");
        BackgroundImage.enabled = false;
        itemSprite.enabled = false;
        amount.text = ("");
        despriction.text = ("");
    }
    public bool ItemAlreadyInInventory(int i)
    {
        for(int f = 0; f < InventoryItems.Count; f++)
        {
            if(InventoryItems[f].isFilled == true)
            {
                if (i == InventoryItems[f].thisItem.itemID)
                {
                    currentPlace = f;
                    return true;
                }
            }
        }
        return false;
    }
    public void Emptyplace()
    {
        for(int i = 0; i < InventoryItems.Count; i++)
        {
            if(InventoryItems[i].isFilled == false)
            {
                currentPlace = i;
                return;
            }
        }
    }
    public void UpdateSprites()
    {
        for(int i = 0; i < InventorySlots.Count; i++)
        {
            //print(InventoryItems[i].thisItem);
            if (InventoryItems[i].isFilled == true)
            {
                InventorySlots[i].sprite = InventoryItems[i].spriteOfThisItem;
            }
            else
            {
                InventorySlots[i].sprite = null;
            }
            
        }
    }

}
