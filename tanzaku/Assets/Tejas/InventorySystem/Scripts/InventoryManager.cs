using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot;

    public ItemSO[] itemSOs;

    [Header("UI Resources")]
    public Sprite emptySlotSprite; // Set this in the Inspector
    public Image itemImage; // Drag the UI Image used for the item's icon


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && menuActivated)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && !menuActivated)
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
    }
    public bool UseItem(string itemName)
    {
        for (int i = 0; i < itemSOs.Length; i++)
        {
            if (itemSOs[i].itemName == itemName)
            {
                bool usable = itemSOs[i].UseItem();
                return usable;
            }            
        }
        return false;
    }
    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        for (int i=0; i< itemSlot.Length; i++)
        {
            if (!itemSlot[i].isFull && (itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0))
            {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                if (leftOverItems > 0)
                {
                    leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription);
                }
                return leftOverItems;

            }
        }
        return quantity;
    }


    public void DeselectAllSlots()
    {
        for (int i=0;i< itemSlot.Length;i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }

    public void RemoveItem(Item item)
    {
        bool removed = false;
        for (int i = 0; i < itemSlot.Length; i++)
        {
            Debug.Log($"Checking slot {i}: {itemSlot[i].itemName} x{itemSlot[i].quantity}");

            if (itemSlot[i].itemName == item.itemName && itemSlot[i].quantity > 0)
            {
                Debug.Log($"Removing from slot {i}");

                itemSlot[i].quantity--;

                if (itemSlot[i].quantity <= 0)
                {
                    itemSlot[i].ClearSlot();

                    // 🟡 Set the slot's image to empty
                    if (emptySlotSprite != null && itemSlot[i].itemImage != null)
                    {
                        itemSlot[i].itemImage.sprite = emptySlotSprite;
                        itemSlot[i].itemImage.color = new Color(1, 1, 1, 0.2f); // Optional: Make it translucent
                    }
                }

                removed = true;
                break;
            }
        }

        if (!removed)
            Debug.LogWarning("RemoveItem failed: Item not found in inventory.");
    }

    public ItemSO GetItemSO(string itemName)
    {
        for (int i = 0; i < itemSOs.Length; i++)
        {
            if (itemSOs[i].itemName == itemName)
            {
                return itemSOs[i];
            }
        }
        return null;
    }

}
