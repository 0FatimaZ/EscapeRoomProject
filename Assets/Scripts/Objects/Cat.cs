using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public GameObject tounge;
    public GameObject colorpuzzle;
    
    Vector3 catcollider;
    public GameObject insidemouth;

    private void Start()
    {
        catcollider = insidemouth.transform.position;
    }
    void OnTriggerEnter(Collider other) 
    {
        if (other.transform.tag == "Tongue")
        {
            colorpuzzle.SetActive(true);
            other.gameObject.transform.position = catcollider;
        }
    }
}
