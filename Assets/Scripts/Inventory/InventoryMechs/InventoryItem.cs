using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEditor.Progress;

[Serializable]
public class InventoryItem
{
    public ItemData itemData;
    public int stackSize = 0;
    public int objectCount = 1;
    public Vector3 originalPlacementPosition;

    public InventoryItem(ItemData item)
    {
        itemData = item;
        AddToStack();
    }

    public void AddToStack()
    {
        stackSize++;
    }


    public void RemoveFromStack()
    {
        stackSize--;
        if (stackSize < 0)
        {
            stackSize = 0;
        }
    }

    public void AddObject()
    {
        objectCount++;
    }

    public void RemoveObject()
    {
        objectCount--;
        if (objectCount < 0)
        {
            objectCount = 0;
        }
    }

    

}
