using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEditor.Progress;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using Unity.Mathematics;

[Serializable]
public class InventoryItem
{
    public ItemData itemData;
    public int stackSize = 0;
    public int objectCount = 1;
    public Vector3 originalPlacementPosition;
    public Scale originalsize;
    public quaternion originalrotation;
    public Collider collider;

    public InventoryItem(ItemData item)
    {
        itemData = item;
        collider = item.prefab.GetComponent<Collider>();
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
