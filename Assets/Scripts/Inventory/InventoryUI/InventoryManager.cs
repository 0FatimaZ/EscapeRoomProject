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


    public List<ItemData> AllItems = new List<ItemData>();

    [Serialize] public Dictionary<string, GameObject> iconToObjectPrefabMap = new Dictionary<string, GameObject>();

    // New method to instantiate 3D objects based on ItemData

    //RELEVANT
    public void Instantiate3DObject(string itemDatadisplayName, Vector3 originalPlacementPosition)
    {

        GameObject prefabToInstantiate;

        // Find the 3D object prefab to instantiate based on the itemData's icon name
        if (iconToObjectPrefabMap.TryGetValue(itemDatadisplayName, out prefabToInstantiate))
        {
            Debug.Log(prefabToInstantiate);
            Instantiate(prefabToInstantiate, originalPlacementPosition, prefabToInstantiate.transform.rotation);
        }
    }

    private void Start()
    {
        for (int i = 0; i < AllItems.Count; i++)
        {
            iconToObjectPrefabMap.Add(AllItems[i].displayName, AllItems[i].prefab);
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
