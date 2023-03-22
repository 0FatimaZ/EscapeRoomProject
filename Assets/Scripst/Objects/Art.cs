using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Art : MonoBehaviour
{
    public GameObject art_txt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            if (GameObject.Find("Player").GetComponent<PlayerMove>().Art == true)
            {
                art_txt.SetActive(true);
            }


        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            if (GameObject.Find("Player").GetComponent<PlayerMove>().Art == true)
            {
                art_txt.SetActive(false);
            }

        }
    }
}
