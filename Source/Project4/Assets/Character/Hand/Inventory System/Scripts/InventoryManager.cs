using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static bool inventoryIsOpen;
    public GameObject Inventory;
    public CamMouseLook camMouseLook;
    public CamMouseLook handMouseLook;
    public PlayerMovement playermovement;
<<<<<<< HEAD
    
=======
    public GameObject uiBook;
    public PlayerBodyScript playerbodyScript;
>>>>>>> origin/master

    void Start()
    {
        Inventory.GetComponent<Inventory>().UpdateSprites();
        Inventory.GetComponent<Inventory>().DisplayNothing();
        CloseInventory();
    }
    void Update ()
    {
		if (Input.GetButtonDown("Inventory"))
        {
            if (inventoryIsOpen == false)
            {
                inventoryIsOpen = true;
                OpenInventory();
            }else if (inventoryIsOpen == true)
            {
                inventoryIsOpen = false;
                CloseInventory();
                Inventory.GetComponent<Inventory>().DisplayNothing();
            }
        }
        if (Input.GetButtonDown("Cancel"))
        {
            if (inventoryIsOpen == true)
            {
                inventoryIsOpen = false;
                CloseInventory();
                Inventory.GetComponent<Inventory>().DisplayNothing();
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

        }
	}
    public void OpenInventory()
    {
        Inventory.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        Inventory.GetComponent<Inventory>().UpdateSprites();
        camMouseLook.enabled = false;
        handMouseLook.enabled = false;
        playermovement.enabled = false;
        uiBook.SetActive(true);
        
        

    }
    public void CloseInventory()
    {
        Inventory.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        camMouseLook.enabled = true;
        handMouseLook.enabled = true;
        playermovement.enabled = true;
        uiBook.SetActive(false);     
    }
}
