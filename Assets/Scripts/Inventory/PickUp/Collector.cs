using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        ICollectible collectible = collision.transform.GetComponent<ICollectible>();
        print("IsNull fungere ikke");
        if (collectible != null)
        {
            //if (Input.GetKeyDown(KeyCode.P))
            {
                collectible.Collect();
            }

        }
    }

}
