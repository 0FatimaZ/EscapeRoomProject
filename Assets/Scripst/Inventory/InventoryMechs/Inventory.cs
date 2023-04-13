using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static event Action<List<InventoryItem>> OnInventoryChange;
    
    
    
    
    public List<InventoryItem> inventory = new List<InventoryItem>();
    private Dictionary<ItemData, InventoryItem> itemDictionary = new Dictionary<ItemData, InventoryItem>
    



    private void OnEnable()
    {
       // PickUpObject.Collected += Add;
    }

    private void OnDisable()
    {
     // PickUpObject.Collected -= Add;
    }

    public void Add(ItemData itemData)
    {
        
        if(itemDictionary.TryGetValue(itemData))
        {

        }
        InventoryItem newitem = gameObject.AddComponent<InventoryItem>();
        inventory.Add(newitem);
        OnInventoryChange?.Invoke(inventory);

    }

}

