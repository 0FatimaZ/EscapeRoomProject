using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PickUpObject : MonoBehaviour, ICollectible
{
    public static PickUpItems Collected;
    public delegate void PickUpItems(ItemData itemData);
    public ItemData itemData;
    public Vector3 originalPlacementPosition;
    
    public void Collect()
    {
        originalPlacementPosition = transform.position;
        Destroy(gameObject);
        Collected?.Invoke(itemData);
    }

    

}
