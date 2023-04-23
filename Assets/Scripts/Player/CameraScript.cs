using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.Netcode;

public class CameraScript : NetworkBehaviour
{
    [Header("Camera Rotation")]
    public float mouseSensitivity = 5.0f;
    public float mousesmoothing = 2.0f;
    public Transform playerbody;
    float xRotation = 0;

    private void Start()
    {
        if (!IsLocalPlayer())
        {
            // Disable the camera for non-local players
            gameObject.SetActive(false);
            return;
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsLocalPlayer())
        {
            // Don't update the camera for non-local players
            return;
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 90, 0);
        playerbody.Rotate(Vector3.up * mouseX);
    }

   public new bool IsLocalPlayer()
    {
        if (NetworkManager.Singleton != null && NetworkManager.Singleton.IsListening)
        {
            if (NetworkManager.Singleton.LocalClientId == base.OwnerClientId)
            {
                return true;
            }
        }

        return false;
    }
}
