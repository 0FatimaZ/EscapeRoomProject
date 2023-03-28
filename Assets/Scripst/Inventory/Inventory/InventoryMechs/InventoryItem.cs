using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public ItemData itemdata;

    public InventoryItem(ItemData item)
    {
        itemdata = item;
    }

}
