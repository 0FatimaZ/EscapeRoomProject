using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winner : MonoBehaviour
{
    [Header("Ending")]
    public GameObject audiosource;
    public GameObject EndingCam1;
    public GameObject EndingCam2;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
            EndingCam1.SetActive(true);
            audiosource.SetActive(false);
            StartCoroutine(FinishCut());
        }

        if (other.gameObject.CompareTag("Player2"))
        {
            EndingCam2.SetActive(true);
            audiosource.SetActive(false);
            StartCoroutine(FinishCut());
        }


    }

    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(15);
        SceneManager.LoadScene("End");
    }
}
