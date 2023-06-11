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
    public GameObject InventoryBar;
    public Button removebutton;
    public Inventory inventory;


    public List<InventorySlot> InventorySlots = new List<InventorySlot>(10);

    public List<ItemData> AllItems = new List<ItemData>();

    [Serialize] public Dictionary<string, GameObject> iconToObjectPrefabMap = new Dictionary<string, GameObject>();


    //At finde det objekt der skal spawnes
    public void Instantiate3DObject(string itemDatadisplayName, Vector3 originalPlacementPosition)
    {
        GameObject prefabToInstantiate;
        if (iconToObjectPrefabMap.TryGetValue(itemDatadisplayName, out prefabToInstantiate))
        {
            Instantiate(prefabToInstantiate, originalPlacementPosition, prefabToInstantiate.transform.rotation);
            print("Instatiate metode fungerer");
        }
    }

    //At udfylde dictionary med items navne og prefabs (listen af alle objekter udfyldt i unity)
    private void Start()
    {
        print("start accesed");
        for (int i = 0; i < AllItems.Count; i++)
        {
            print("for kører");
            iconToObjectPrefabMap.Add(AllItems[i].displayName, AllItems[i].prefab);
            print("Dictionary filled");
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


    //At tegne inventory UI

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

    
    //At oprette et inventory slot
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
