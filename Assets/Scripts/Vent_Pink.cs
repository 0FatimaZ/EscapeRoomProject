//using System.Collections;
//using System.Collections.Generic;
//using Unity.Burst.CompilerServices;
//using UnityEngine;

//public class Vent_Pink : MonoBehaviour
//{
//    Vector3 DropoffP;

//    public GameObject othersideP;

    
//    void Start()
//    {
//        DropoffP = othersideP.transform.position;
//    }

//    private void OnTriggerEnter(Collider hit)
//    {
//        if (hit.transform.tag != "Player1")
//        {
//            print("dwqW");
//            hit.gameObject.transform.position = DropoffP;
//        }
//    }
//}
