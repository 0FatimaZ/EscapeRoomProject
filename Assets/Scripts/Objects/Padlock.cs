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
    public Wall wallscript;
    public GameObject interaction;
    private Transform playerTransform;
    private CharacterController characterController;
    


    void Start()
    {
        Color newColor;
        ColorUtility.TryParseHtmlString("#63672A", out newColor);
        codeText.color = newColor;
        codeText.fontSize = 54;
        initialFontColor = codeText.color;
        initialFontSize = (int)codeText.fontSize;
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

        playerTransform = GameObject.FindWithTag("Player").transform;
        characterController = playerTransform.GetComponent<CharacterController>();

        if (padlockUnlocked) 
        {
            characterController.enabled = true;
            UI.gameObject.SetActive(false);
            wallscript.OpenorClose();
            //UI.SetActive(false);
            //characterController.enabled = false;
            Destroy(interaction);

        }
    }


}