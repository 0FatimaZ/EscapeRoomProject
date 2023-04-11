using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PickUpObject : MonoBehaviour, ICollectible
{
    public static PickUpItems Collected;
    public delegate void PickUpItems(ItemData itemData);
    public ItemData itemdata;
    
    public void Collect()
    {
        Destroy(gameObject);
        gameObject.transform.position = player.transform.position + (player.transform.forward * 0.5f); //at ændre gameobject position til et andet sted
        Collected?.Invoke(itemdata);
    }

    

}
