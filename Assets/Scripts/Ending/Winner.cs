using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winner : MonoBehaviour
{
    [Header("Sounds")]
    public GameObject audiosource;
    public GameObject endvoice;
    public GameObject scream;

    [Header("Cameras")]
    public GameObject EndingCam1;
    public GameObject EndingCam1_2;
    public GameObject EndingCam2;
    public GameObject EndingCam2_2;
    public GameObject black;
    public GameObject Canvasend;
    private CharacterController characterController;
    private Transform playerTransform;


    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        characterController = playerTransform.GetComponent<CharacterController>();
    }

// Update is called once per frame
void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            Canvasend.SetActive(true);
            audiosource.SetActive(false);
            StartCoroutine(Endcam1());
            StartCoroutine(FinishCut());
        }

        if (other.gameObject.layer == 6)
        {
            Canvasend.SetActive(true);
            audiosource.SetActive(false);
            StartCoroutine(Endcam2());
            StartCoroutine(FinishCut());
        }


    }

    IEnumerator Endcam1()
    {
        black.SetActive(true);
        endvoice.SetActive(true);
        yield return new WaitForSeconds(30);
        scream.SetActive(true);
        EndingCam1.SetActive(true);
        yield return new WaitForSeconds(5);
        EndingCam1.SetActive(false);
        EndingCam1_2.SetActive(true);
        yield return new WaitForSeconds(5);
        EndingCam1_2.SetActive(false);
    }

    IEnumerator Endcam2()
    {
        black.SetActive(true);
        endvoice.SetActive(true);
        yield return new WaitForSeconds(30);
        scream.SetActive(true);
        EndingCam2.SetActive(true);
        yield return new WaitForSeconds(5);
        EndingCam2.SetActive(false);
        EndingCam2_2.SetActive(true);
        yield return new WaitForSeconds(5);
        EndingCam1_2.SetActive(false);
    }

    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(40);
        SceneManager.LoadScene("End");
    }
}
