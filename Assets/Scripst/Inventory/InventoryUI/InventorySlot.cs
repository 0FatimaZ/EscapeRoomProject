using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image ObjectIcon;
    public TextMeshProUGUI NameLabel;
    public TextMeshProUGUI stackSize;
    


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

        ObjectIcon.sprite = item.itemData.icon;
        NameLabel.text = item.itemData.displayName;
        stackSize.text = item.stackSize.ToString();
        Debug.Log("stacksize: " + item.stackSize);

    }

}
