using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    /*
    public GameObject UI;
    public Image interactionText;
    public float interactionDistance = 1.0f;
    private Transform playerTransform;
    private CharacterController characterController;
    private bool wasCharacterControllerEnabled;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        characterController = playerTransform.GetComponent<CharacterController>();
        //interactionText.gameObject.SetActive(false);
        UI.gameObject.SetActive(false);
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance <= interactionDistance)
        {
            //interactionText.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                UI.gameObject.SetActive(!UI.gameObject.activeSelf);
                if (UI.gameObject.activeSelf)
                {
                    wasCharacterControllerEnabled = characterController.enabled;
                    characterController.enabled = false;
                }
                else
                {
                    characterController.enabled = wasCharacterControllerEnabled;
                }
            }
        }
        else
        {
            //interactionText.gameObject.SetActive(false);
        }
    }
    */
}
