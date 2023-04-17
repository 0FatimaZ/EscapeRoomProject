using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

//[System.Serializable]
/*public struct SubtitleText
{
    public float time;
    public string text;
}*/

public class CameraScript : MonoBehaviour


{
    [Header("Camera Rotation")]
    public float mouseSensitivity = 5.0f;
    public float mousesmoothing = 2.0f;
    public Transform playerbody;
    float xRotation = 0;

    

    [Header("Subtitles")]
    public GameObject start_vc;
    GameObject subtitleGO;
    TextMeshProUGUI subtitles;
    public SubtitleText[] subtitleText;



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

    IEnumerator Start_message()
    {
        yield return new WaitForSeconds(34);
        start_vc.SetActive(false);
    }

    /*IEnumerator SubtitleCoroutine()
    {
        subtitleGO.SetActive(true);
        foreach(var voiceLine in subtitleText)
        {
            subtitles.text = voiceLine.text;

            yield return new WaitForSecondsRealtime(voiceLine.time);
        }
    }

    void StartSubtitles()
    {
        StartCoroutine(SubtitleCoroutine());
    }*/
   
}
