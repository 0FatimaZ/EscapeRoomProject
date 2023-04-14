using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject SlotPrefab;
    public List<InventorySlot> InventorySlots = new List<InventorySlot>(10);
   
   

    private void OnEnable()
    {
        Inventory.OnInventoryChange += DrawInventory;
    }

    private void OnDisable()
    {
        Inventory.OnInventoryChange -= DrawInventory;
    }



    // CRASHES THE GAME
    //void ResetInventory()
    //{
    //    for(int i = 0; i < transform.childCount; i++)
    //    {
    //        Destroy(transform.GetChild(0).gameObject);
    //    }
    //    //foreach(Transform childTransform in transform)
    //    //{
    //    //    Destroy(childTransform.gameObject);
    //    //}
    //    InventorySlots = new List<InventorySlot>(10);

    //}

    void DrawInventory(List<InventoryItem> inventory) 
    //ArgumentOutOfRangeException: Index was out of range. Must be non-negative and less than the size of the collection.

    {

        //ResetInventory();

        // create new slots until the InventorySlots list has the same count as the inventory list
        while (InventorySlots.Count < inventory.Count)
        {
            CreateInventorySlot();
        }

        for (int i = 0; i < inventory.Count; i++)
        {
            InventorySlots[i].DrawSlot(inventory[i], InventorySlots[i].GetStackSize());
        }



        //ResetInventory();

        //for(int i = 0; i < InventorySlots.Capacity; i++)
        //{
        //    CreateInventorySlot();
        //}

        //for (int i = 0; i < inventory.Count; i++)
        //{
        //    InventorySlots[i].DrawSlot(inventory[i]);
        //}

    }

    void CreateInventorySlot()
    //MissingReferenceException: The object of type 'GameObject' has been destroyed but you are still trying to access it.
    {


        if (SlotPrefab == null) return; // add null check here

        GameObject newslot = Instantiate(SlotPrefab);
        if (newslot == null) return; // add null check here

        newslot.transform.SetParent(transform, false);

        InventorySlot newslotComponent = newslot.GetComponent<InventorySlot>();

        if (newslotComponent != null)
        {
            newslotComponent.ClearSlot();
            InventorySlots.Add(newslotComponent);
        }
        


    }





    //GameObject newslot = Instantiate(SlotPrefab);
    //newslot.transform.SetParent(transform, false);

    //InventorySlot newslotComponent = newslot.GetComponent<InventorySlot>();

    //if (newslotComponent != null)
    //{
    //    newslotComponent.ClearSlot();
    //    InventorySlots.Add(newslotComponent);
    //}
}
