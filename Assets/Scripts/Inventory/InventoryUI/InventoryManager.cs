using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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


    
   
    void DrawInventory(List<InventoryItem> inventory) 

    {
        while (InventorySlots.Count < inventory.Count)
        {
            CreateInventorySlot();
        }

        for (int i = 0; i < inventory.Count; i++)
        {
            InventorySlots[i].DrawSlot(inventory[i], InventorySlots[i].GetStackSize());
        }


    }

    void CreateInventorySlot()
    { 


        if (SlotPrefab == null) return; // add null check here

        GameObject newslot = Instantiate(SlotPrefab);
        if (newslot == null) return; // add null check here

        newslot.transform.SetParent(transform, false);

        InventorySlot newslotComponent = newslot.GetComponent<InventorySlot>();

        if (newslotComponent != null)
        {
            newslotComponent.ClearSlot();
            //newslotComponent.RemoveButton.onClick.AddListener(newslotComponent.RemoveItem);
            InventorySlots.Add(newslotComponent);
        }
        


    }

    //private void Update()
    //{
    //    if (.ItemData != null)
    //    {
    //        transform.position = MouseButton.current.position.ReadValue()
    //    }
    //}





    //GameObject newslot = Instantiate(SlotPrefab);
    //newslot.transform.SetParent(transform, false);

    //InventorySlot newslotComponent = newslot.GetComponent<InventorySlot>();

    //if (newslotComponent != null)
    //{
    //    newslotComponent.ClearSlot();
    //    InventorySlots.Add(newslotComponent);
    //}

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

}
