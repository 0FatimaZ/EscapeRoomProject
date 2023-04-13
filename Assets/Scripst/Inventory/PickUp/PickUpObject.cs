using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PickUpObject : MonoBehaviour, ICollectible
{
    public static PickUpItems Collected;
    public delegate void PickUpItems(ItemData itemData);
    public ItemData itemData;
    
    public void Collect()
    {
        Debug.Log("Collided");
        Destroy(gameObject);
        Collected?.Invoke(itemData);
    }

    

}
