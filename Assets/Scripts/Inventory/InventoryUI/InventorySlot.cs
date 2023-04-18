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
    public GameObject itemPrefab;
    public ItemData itemData;
    public Inventory inventory;



    public void ClearSlot()
    {
        ObjectIcon.enabled = false;
        NameLabel.enabled = false;
        stackSize.enabled = false;
        
        
    }

    public TextMeshProUGUI GetStackSize()
    {
        return stackSize;
    }

    public void DrawSlot(InventoryItem item, TextMeshProUGUI stackSize)
    {
        if(item == null)
        {
            ClearSlot();
            return; 
        }

        
        ObjectIcon.enabled = true;
        NameLabel.enabled = true;
        stackSize.enabled = true;
        removebutton.enabled = true;
        

        ObjectIcon.sprite = item.itemData.icon;
        NameLabel.text = item.itemData.displayName;
        stackSize.text = item.stackSize.ToString();
        

    }


    public void RemoveItem(InventoryItem item)
    {
        if (item != null)
        {
            Instantiate(itemPrefab, Camera.main.transform.position + Camera.main.transform.forward, Quaternion.identity);
            inventory.Remove(item.itemData);
        }
    }

    public void DecreaseStackSize()
    {
        Debug.Log("Clicked a remove button");
        item.stackSize--;
        DrawSlot(item, GetStackSize());
        if (item.stackSize <= 0)
        {
            RemoveItem(item);
        }
    }

    //void Start()
    //{
    //    removebutton.onClick.AddListener(() => RemoveItem(slot));
    //}
}
