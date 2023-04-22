using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class CameraScript : MonoBehaviour


{
    [Header("Camera Rotation")]
    public float mouseSensitivity = 5.0f;
    public float mousesmoothing = 2.0f;
    public Transform playerbody;
    float xRotation = 0;

    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 90, 0);
        playerbody.Rotate(Vector3.up * mouseX);

        
    }

   
}
