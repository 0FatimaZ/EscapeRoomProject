using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image ObjectIcon;
    public TextMeshProUGUI NameLabel;
    public TextMeshProUGUI Stacksize;
    


    public void ClearSlot()
    {
        ObjectIcon.enabled = false;
        NameLabel.enabled = false;
        Stacksize.enabled = false;
    }

    public void DrawSlot(InventoryItem item)
    {
        if(item == null)
        {
            ClearSlot();
            return; 
        }
        ObjectIcon.enabled = true;
        NameLabel.enabled = true;
        Stacksize.enabled = true;

        ObjectIcon.sprite = item.itemData.icon;
        NameLabel.text = item.itemData.displayName;
        Stacksize.text = item.stackSize.ToString();

    }

}
