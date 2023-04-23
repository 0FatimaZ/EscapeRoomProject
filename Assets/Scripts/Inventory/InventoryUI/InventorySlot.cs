using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//using static UnityEditor.Progress;

public class InventorySlot : MonoBehaviour
{
    public Image ObjectIcon;
    public TextMeshProUGUI NameLabel;
    public TextMeshProUGUI stackSize;
    public Button removebutton;
    private InventoryItem item;
    public ItemData itemData;
    public Inventory inventory;
    public InventoryManager inventoryManager;
    public Transform cameraUnity;
    public Transform cameraUnity2;


    //RELEVANT
    // OnClick for at fjerne og spawne objekt
    public void OnClick()
       
    {
        print("onclick accesed");
        if (item != null)
        {
            if (cameraUnity)
            {
                inventoryManager.Instantiate3DObject(item.itemData.displayName, new Vector3(cameraUnity.position.x, cameraUnity.position.y, cameraUnity.position.z + 100));
            }
            else
            {
                inventoryManager.Instantiate3DObject(item.itemData.displayName, new Vector3(cameraUnity2.position.x, cameraUnity2.position.y, cameraUnity2.position.z + 100));
            }
        }
        print("item = null");

    }

    //At finde relevante tags
    private void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("inventoryManager").GetComponent<InventoryManager>();
        cameraUnity = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        cameraUnity2 = GameObject.FindGameObjectWithTag("MainCamera2").GetComponent<Transform>();
    }
    //At clear et slot
    public void ClearSlot()
    {
        ObjectIcon.enabled = false;
        NameLabel.enabled = false;
        stackSize.enabled = false;
        removebutton.enabled = false;
    }

    //At slette et slot
    public void DeleteSlot()
    {
        if (inventoryManager != null)
        {
            inventoryManager.InventorySlots.Remove(this);
        }

        Destroy(gameObject);
    }

    public TextMeshProUGUI GetStackSize()
    {
        return stackSize;
    }

    
    //At udfylde slottet
    public void DrawSlot(InventoryItem item, TextMeshProUGUI stackSize)
    {
        if (item == null)
        {
            ClearSlot();
            return;
        }

        this.item = item;
        itemData = item.itemData;

        ObjectIcon.enabled = true;
        NameLabel.enabled = true;
        stackSize.enabled = true;
        removebutton.enabled = true;

        ObjectIcon.sprite = item.itemData.icon;
        NameLabel.text = item.itemData.displayName;
        stackSize.text = item.stackSize.ToString();
    }

    //At fjerne fra slot og inventory og spawn objektet der fjernes
    public void DecreaseStackSize()
    {
        
        item.stackSize--;
        DrawSlot(item, GetStackSize());
        print("Stacksize fjernes");

        if (cameraUnity)
        {
            inventoryManager.Instantiate3DObject(item.itemData.displayName, cameraUnity.position);
            print("Yes cam 1");
        }

        if (cameraUnity2)
        {
            inventoryManager.Instantiate3DObject(item.itemData.displayName, cameraUnity2.position);
            print("yes cam 2");
        }
       
        item.collider.enabled = true;

        if (item.stackSize <= 0)
        {
            inventory.Remove(item.itemData);
            DeleteSlot();

        }
    }
}

    