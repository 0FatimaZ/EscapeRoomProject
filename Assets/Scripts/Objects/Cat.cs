using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public GameObject tounge;
    public GameObject colorpuzzle;

    void OnTriggerEnter(Collider other) 
    {
        if (other.transform.tag == "Tongue")
        {
            colorpuzzle.SetActive(true);
        }
    }
}