using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    //private void OnTriggerEnter(Collider collision)
    //{
    //    ICollectible collectible = collision.GetComponent<ICollectible>();
    //    if(collectible != null)
    //    {
    //        collectible.Collect();


    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        ICollectible collectible = collision.transform.GetComponent<ICollectible>();
        print("IsNull fungere ikke");
        if(collectible != null)
        {
            print("fewhlj");
            collectible.Collect();

        }
    }

}
