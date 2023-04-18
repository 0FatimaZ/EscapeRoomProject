using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static event Action<List<InventoryItem>> OnInventoryChange;
 


    public List<InventoryItem> inventory = new List<InventoryItem>();
    private Dictionary<ItemData, InventoryItem> itemDictionary = new Dictionary<ItemData, InventoryItem>();


    


    private void OnEnable()
    {
       PickUpObject.Collected += Add;
    }

    private void OnDisable()
    {
        PickUpObject.Collected -= Add;
    }


    

    public void Add(ItemData itemData)
    {
        
        if(itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.AddToStack();
            OnInventoryChange?.Invoke(inventory);

        }
        else
        {
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);
            itemDictionary.Add(itemData, newItem);
            OnInventoryChange?.Invoke(inventory);

        }

    }

    public void Remove(ItemData itemData)
    {
        
        if (itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.RemoveFromStack();
            if(item.stackSize == 0)
            {
                inventory.Remove(item);
                itemDictionary.Remove(itemData);
            }
        }
    }

    //public List<InventoryItem> GetInventory()
    //{
    //    return inventory;
    //}

    //internal static void Remove(InventoryItem item)
    //{
    //    throw new NotImplementedException();
    //}
}

