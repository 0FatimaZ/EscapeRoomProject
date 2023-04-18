using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventorySlot : MonoBehaviour
{
    public Image ObjectIcon;
    public TextMeshProUGUI NameLabel;
    public TextMeshProUGUI stackSize;
    public Button removebutton;
    private InventoryItem item;
    public ItemData itemData;
    public Inventory inventory;
    public InventoryManager inventoryManager;


    // New method to handle click events on inventory slots
    public void OnClick()
    {
        if (item != null)
        {
            inventoryManager.Instantiate3DObject(item.itemData);
            Debug.Log("Instantiated:" + (item.itemData));
        }
    }


    // New method to set the inventoryManager field
    public void SetInventoryManager(InventoryManager manager)
    {
        inventoryManager = manager;
    }

    public void ClearSlot()
    {
        ObjectIcon.enabled = false;
        NameLabel.enabled = false;
        stackSize.enabled = false;
        removebutton.enabled = false;
    }

    public void DeleteSlot()
    {
        // Remove the current slot from the InventoryManager's InventorySlots list
        if (inventoryManager != null)
        {
            inventoryManager.InventorySlots.Remove(this);
        }

        // Destroy this gameobject
        Destroy(gameObject);
    }

    public TextMeshProUGUI GetStackSize()
    {
        return stackSize;
    }

    public void DrawSlot(InventoryItem item, TextMeshProUGUI stackSize)
    {
        if (item == null)
        {
            ClearSlot();
            return;
        }

        this.item = item;
        itemData = item.itemData;

        ObjectIcon.enabled = true;
        NameLabel.enabled = true;
        stackSize.enabled = true;
        removebutton.enabled = true;

        ObjectIcon.sprite = item.itemData.icon;
        NameLabel.text = item.itemData.displayName;
        stackSize.text = item.stackSize.ToString();
    }

    public void DecreaseStackSize()
    {
        
        item.stackSize--;
        DrawSlot(item, GetStackSize());
        if (item.stackSize <= 0)
        {
            inventory.Remove(item.itemData);
            DeleteSlot();
        }
    }
}

    