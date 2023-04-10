using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject SlotPrefab;
    public List<InventorySlot> InventorySlots = new List<InventorySlot>(3);
   
   

    private void OnEnable()
    {
        Inventory.OnInventoryChange += DrawInventory;
    }

    private void OnDisable()
    {
        Inventory.OnInventoryChange -= DrawInventory;
    }




    void ResetInventory()
    {
        foreach(Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }
        InventorySlots = new List<InventorySlot>(3);

    }

    void DrawInventory(List<InventoryItem> inventory)
    {
        ResetInventory();

        for(int i =0; i < InventorySlots.Capacity; i++)
        {
            CreateInventorySlot();
        }

        for (int i = 0; i < InventorySlots.Count; i++)
        {
            InventorySlots[i].DrawSlot(inventory[i]);
        }

    }

    void CreateInventorySlot()
    {
        GameObject newslot = Instantiate(SlotPrefab);
        newslot.transform.SetParent(transform, false);

        InventorySlot newslotComponent = newslot.GetComponent<InventorySlot>();
        newslotComponent.ClearSlot();

        InventorySlots.Add(newslotComponent);


    }
}