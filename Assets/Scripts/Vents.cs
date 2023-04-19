using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Vents : MonoBehaviour
{
    Vector3 Dropoff;

    public GameObject otherside;

    
    void Start()
    {
        Dropoff = otherside.transform.position;
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.transform.tag != "Player2")
        {
            print("dwqW");
            hit.gameObject.transform.position = Dropoff;
        }
    }
}
