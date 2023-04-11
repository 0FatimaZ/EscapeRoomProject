using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static event Action<List<InventoryItem>> OnInventoryChange;
    
    
    
    
    public List<InventoryItem> inventory = new List<InventoryItem>();
    



    private void OnEnable()
    {
       // PickUpObject.Collected += Add;
    }

    private void OnDisable()
    {
     // PickUpObject.Collected -= Add;
    }

    public void Add(ItemData itemdata)
    {
        InventoryItem newitem = gameObject.AddComponent<InventoryItem>();
        inventory.Add(newitem);
        OnInventoryChange?.Invoke(inventory);

    }

}

