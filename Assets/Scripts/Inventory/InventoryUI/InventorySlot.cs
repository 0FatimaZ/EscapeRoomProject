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
    //public GameObject Item3D;
    //public Button RemoveButton;


    private InventoryItem item;

    public void ClearSlot()
    {
        ObjectIcon.enabled = false;
        NameLabel.enabled = false;
        stackSize.enabled = false;
        //RemoveButton.enabled = false;
        
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
        //RemoveButton.enabled = true;

        ObjectIcon.sprite = item.itemData.icon;
        NameLabel.text = item.itemData.displayName;
        stackSize.text = item.stackSize.ToString();
        

    }

    //public void RemoveItem()
    //{
    //    ClearSlot();

    //    // Place the 3D object in front of the player
    //    Vector3 spawnPosition = Camera.main.transform.position + Camera.main.transform.forward * 2f;
    //    Instantiate(item.itemData.prefab, spawnPosition, Quaternion.identity);
    //}


}
