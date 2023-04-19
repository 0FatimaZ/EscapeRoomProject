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
    //private Transform originalParent;


    //RELEVANT
    // New method to handle click events on inventory slots
    public void OnClick()
    {
        if (item != null)
        {
            inventoryManager.Instantiate3DObject(item.itemData, item.originalPlacementPosition);
            Debug.Log("Instantiated:" + (item.itemData));
        }

        Debug.Log("Item is null");
    }



    //VIRKER
    public void ClearSlot()
    {
        ObjectIcon.enabled = false;
        NameLabel.enabled = false;
        stackSize.enabled = false;
        removebutton.enabled = false;
    }

    //VIRKER
    public void DeleteSlot()
    {
        if (inventoryManager != null)
        {
            inventoryManager.InventorySlots.Remove(this);
        }

        Destroy(gameObject);
    }

    public TextMeshProUGUI GetStackSize()
    {
        return stackSize;
    }

    //VIRKER
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

    //VIRKER & RELEVANT
    public void DecreaseStackSize()
    {
        
        item.stackSize--;
        DrawSlot(item, GetStackSize());
        
        item.originalPlacementPosition = transform.position;

        item.collider.enabled = true;

        // Set the parent back to the original parent (if it had one)
        //transform.parent = originalParent;

        if (item.stackSize <= 0)
        {
            inventory.Remove(item.itemData);
            DeleteSlot();

        }
    }
}

    