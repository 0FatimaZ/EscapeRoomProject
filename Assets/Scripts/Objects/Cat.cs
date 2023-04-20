using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public GameObject tounge;
    public GameObject colorpuzzle;

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject == tounge) 
        {
            colorpuzzle.SetActive(true);
        }
    }
}
