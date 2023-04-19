using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject SlotPrefab;
    public List<InventorySlot> InventorySlots = new List<InventorySlot>(10);
    public GameObject InventoryBar;
    public Button removebutton;
    public Inventory inventory;

    public Dictionary<ItemData, GameObject> iconToObjectPrefabMap = new Dictionary<ItemData, GameObject>();

    // New method to instantiate 3D objects based on ItemData

    //RELEVANT
    public void Instantiate3DObject(ItemData itemData, Vector3 originalPlacementPosition)
    {
        if (iconToObjectPrefabMap == null)
        {
            //return;
            Debug.Log("Icon to object prefab is null");
        }

        GameObject prefabToInstantiate;

        // Find the 3D object prefab to instantiate based on the itemData's icon name
        if (iconToObjectPrefabMap.TryGetValue(itemData, out prefabToInstantiate))
        {
            Debug.Log(prefabToInstantiate);
            Instantiate(prefabToInstantiate, originalPlacementPosition, Quaternion.identity);
        }
    }

    private void OnEnable()
    {
        Inventory.OnInventoryChange += DrawInventory;
    }

    private void OnDisable()
    {
        Inventory.OnInventoryChange -= DrawInventory;
    }

    public void DrawInventory(List<InventoryItem> inventory)
    {
        int max = 10;
        while (InventorySlots.Count < inventory.Count && max > 0)
        {
            max--;
            CreateInventorySlot();
        }

        for (int i = 0; i < inventory.Count; i++)
        {
            InventorySlots[i].DrawSlot(inventory[i], InventorySlots[i].GetStackSize());
        }
    }

    void CreateInventorySlot()
    {
        if (SlotPrefab == null) return;

        GameObject newslot = Instantiate(SlotPrefab);
        if (newslot == null) return;

        newslot.GetComponent<InventorySlot>().inventory = inventory;
        newslot.transform.SetParent(transform, false);

        InventorySlot newslotComponent = newslot.GetComponent<InventorySlot>();

        if (newslotComponent != null)
        {
            newslotComponent.ClearSlot();
            InventorySlots.Add(newslotComponent);
        }
    }
}
