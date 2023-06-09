//using System.Collections;
//using System.Collections.Generic;
//using Unity.Burst.CompilerServices;
//using UnityEngine;

//public class Vent_Black : MonoBehaviour
//{
//    Vector3 DropoffB;
//    Vector3 DropOffP;

//    public GameObject othersideP;
//    public GameObject othersideB;

    
//    void Start()
//    {
//        DropoffB = othersideP.transform.position;
//    }

//    private void OnTriggerEnter(Collider hit)
//    {
//        if (hit.transform.tag != "Player2")
//        {
//            print("dwqW");
//            hit.gameObject.transform.position = DropoffB;
//        }
//    }
//}
