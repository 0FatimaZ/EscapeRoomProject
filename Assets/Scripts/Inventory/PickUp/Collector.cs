using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    public bool collecting;

    ICollectible collectible;

    private void Update()
    {
       if (collecting == true && Input.GetKeyDown(KeyCode.P))
        {
            collectible.Collect();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        collectible = collision.transform.GetComponent<ICollectible>();
        
        if (collectible != null)
        {
            //collectible.Collect();
            collecting = true;
            print("Collectible is not null");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        collecting = false;
    }

}
