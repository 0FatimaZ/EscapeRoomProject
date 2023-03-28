using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour


{
    [Header("Camera Rotation")]
    public float mouseSensitivity = 100;
    public Transform playerbody;
    float xRotation = 0;

    [Header("Objects")]
    
    [Header("Ending")]
    public GameObject EndingCam;
    public GameObject audiosource;
    public GameObject Player;
    public GameObject Fire;
    public bool end = false;




    // Start is called before the first frame update
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
