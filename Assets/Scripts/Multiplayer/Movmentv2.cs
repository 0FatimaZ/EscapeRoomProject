using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;


public class Movmentv2 : NetworkBehaviour
{
   
    public float speed = 5f;

    void Update()
    {
         if (!IsOwner) return;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime;

        transform.position += movement;
    }
}