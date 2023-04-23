using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Unity.Collections.AllocatorManager;

public class Padlock : MonoBehaviour
{
    [SerializeField] TMP_Text codeText;
	[SerializeField] private float delay = 0.5f;
	string codeTextValue = "";
	private int maxLength = 4;
    private string Answer = "5320";
    public GameObject UI;
    public bool padlockUnlocked = false;
    Color initialFontColor;
    int initialFontSize;

    /*
    public GameObject wall;
    public Vector3 destination;
    public float speed = 1f;
    public GameObject padUI;
    public GameObject knife;
    */
    public Wall wallscript;

    void Start()
    {
        Color newColor;
        ColorUtility.TryParseHtmlString("#63672A", out newColor);
        codeText.color = newColor;
        codeText.fontSize = 54;
        initialFontColor = codeText.color;
        initialFontSize = (int)codeText.fontSize;

        //wallscript = GameObject.Find("Wall");
    }

	public void Number(string number)
    {
		if (codeTextValue == "INVALID") return;

		if(codeText.text.Length < maxLength)
		{
			codeTextValue += number.ToString();
		}
    }

	public void DelLast()
	{
		if (codeTextValue == "INVALID") return;
		
		if (codeText.text.Length > 0)
		{
		 	codeTextValue = codeTextValue.Remove(codeText.text.Length - 1);
		}
	}

    public void DelAll()
	{
		codeTextValue = "";
        codeText.text = "";
        codeText.color = initialFontColor;
        codeText.fontSize = initialFontSize;
	}
	
    public void Execute()
    {
        if(codeTextValue == Answer)
        {
            codeTextValue = "CORRECT";
            codeText.text = "CORRECT";
            Color newColor;
            ColorUtility.TryParseHtmlString("#3C8A01", out newColor);
            codeText.color = newColor;
            codeText.fontSize = 23;
            padlockUnlocked = true;
            print(padlockUnlocked);
        }
        else
        {   
            codeTextValue = "INVALID";
            codeText.text = "INVALID";
            Color newColor;
            ColorUtility.TryParseHtmlString("#A21100", out newColor);
            codeText.color = newColor;
            codeText.fontSize = 23;
            Invoke("DelAll", delay);
        }
    }

	void Update () 
	{
		codeText.text = codeTextValue;

        if (padlockUnlocked) 
        {
            //wall.transform.position = Vector3.Lerp(wall.transform.position, destination, Time.deltaTime * speed);
            //knife.SetActive(true);
            //wallscript.GetComponent<Wall>().OpenorClose();
            wallscript.OpenorClose();
            //padUI.SetActive(false);
            UI.SetActive(false);
        }
    }


}



/*
    [SerializeField] private TMP_Text Ans;
    [SerializeField] private int maxLength = 4;
    [SerializeField] private float displayTime = 2.0f;
    [SerializeField] private GameObject uiImage;
    [SerializeField] private Animator myAnimationController;
    [SerializeField] private float delay = 4.0f;
    [SerializeField] private AudioSource button;
    [SerializeField] private AudioSource door;
    [SerializeField] private AudioSource wrong;
    
    private string Answer = "5320";
    private float timeLeft;
    public static bool padlockUnlocked = true;

    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                Ans.text = "";
            }
        }
    }

    public void Number(int number)
    {
        if (Ans.text.Length < maxLength)
        {
            Ans.text += number.ToString();
            button.Play();
        }
    }
    public void Execute()
    {
        if(Ans.text == Answer)
        {
            Ans.text = "Correct";
            padlockUnlocked = false;
            door.Play();
            myAnimationController.SetBool("open", false);
            StartCoroutine(OpenDoorWithDelay());
        }
        else
        {
            Ans.text = "Invalid";
            timeLeft = displayTime;
            wrong.Play();
        }
    }
    private IEnumerator OpenDoorWithDelay()
    {
        yield return new WaitForSeconds(delay);
        uiImage.SetActive(false);
        CharacterController characterController = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
        characterController.enabled = true;
        win();
    }
    public void win()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
*/