using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {

    public int slotNumber;
    public Inventory inventory;
    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (inventory.InventoryItems[item.GetComponentInChildren<SlotInfo>().place-1].isFilled == false)
        {
            int place = DragHandler.dragedItem.GetComponent<SlotInfo>().place;
            //print(inventory.InventoryItems[DragHandler.dragedItem.GetComponent<SlotInfo>().place - 1]);
            inventory.InventoryChangeTwo(item.GetComponentInChildren<SlotInfo>().place - 1, inventory.InventoryItems[DragHandler.dragedItem.GetComponent<SlotInfo>().place-1]);
            inventory.ClearPlace(DragHandler.dragedItem.GetComponent<SlotInfo>().place - 1);
            //DragHandler.dragedItem.transform.SetParent(transform);
            DragHandler.dragedItem = null;
            inventory.UpdateSprites();
        }
    }
}
