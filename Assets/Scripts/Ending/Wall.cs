using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    //[Header("Animation")]
    //public Animator animator;
    //public bool open = false;
    public GameObject knife;
    //public Padlock padlockscript;
    public GameObject wall;
    public Vector3 destination;
    public float speed = 1f;
    public bool moveWall = false;

    void Update() 
    {
        if (moveWall) 
        {
            wall.transform.position = Vector3.Lerp(wall.transform.position, destination, Time.deltaTime * speed);
            knife.SetActive(true);
        }
    }

    public void OpenorClose() 
    {
        moveWall = true;
    }
}

    /*
    void Start()
    {
        //animator = GetComponent<Animator>();

    }

    public void OpenorClose()
    {
   
        wall.transform.position = Vector3.Lerp(wall.transform.position, destination, Time.deltaTime * speed);
        knife.SetActive(true);

        
        
        print("Outside");
        if (padlockscript.padlockUnlocked == true)
        {
            print("Inside");
            wall.transform.position = Vector3.Lerp(wall.transform.position, destination, Time.deltaTime * speed);
            //wallscript.OpenorClose();
            //padUI.SetActive(false);
            //animator.SetBool("isopen", true);
            
            knife.SetActive(true);

        }
        
    }
}
*/
