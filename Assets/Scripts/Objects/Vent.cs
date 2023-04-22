using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Vent : MonoBehaviour
{
    Vector3 Dropoff;

    public GameObject otherside;

    
    void Start()
    {
        Dropoff = otherside.transform.position;
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.transform.tag != "Player")
        {
            print("dwqW");
            hit.gameObject.transform.position = Dropoff;
        }
    }
}
