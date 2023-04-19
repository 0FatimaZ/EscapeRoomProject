using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Vent_Pink : MonoBehaviour
{
    Vector3 Dropoff;

    public GameObject otherside;

    
    void Start()
    {
        Dropoff = otherside.transform.position;
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.transform.tag != "Player1")
        {
            print("dwqW");
            hit.gameObject.transform.position = Dropoff;
        }
    }
}
