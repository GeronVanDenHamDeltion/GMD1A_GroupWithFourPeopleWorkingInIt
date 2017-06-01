using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class InventoryPlace
{
    public bool isFilled;
    public int amount;
    public Image Inventoryslot;
    public Item thisItem;
    public Sprite spriteOfThisItem;
    
}
