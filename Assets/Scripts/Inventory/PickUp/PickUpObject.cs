using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PickUpObject : MonoBehaviour, ICollectible
{
    public static PickUpItems Collected;
    public delegate void PickUpItems(ItemData itemData);
    public ItemData itemData;

    
    public void Collect()
    {
        
        Destroy(gameObject);
        Collected?.Invoke(itemData);
    }

    

}
