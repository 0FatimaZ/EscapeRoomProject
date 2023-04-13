using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Calculator : MonoBehaviour
{
    [SerializeField] TMP_Text codeText;
	[SerializeField] private float delay = 0.5f;
	string codeTextValue = "";
	private int maxLength = 8;


	public void Number(string number)
    {
		if (codeTextValue == "ERROR") return;

		if(codeText.text.Length < maxLength)
		{
			codeTextValue += number.ToString();
		}

    }
	
	public void DelAll()
	{
		codeTextValue = "";
		codeText.text = "";
	}

	public void DelLast()
	{
		if (codeTextValue == "ERROR") return;
		
		if (codeText.text.Length > 0)
		{
		 	codeTextValue = codeTextValue.Remove(codeText.text.Length - 1);
			if (codeText.text.Length <= 0)
			{
				DelAll();
			}
		}
	}

	public void Error()
	{
		codeTextValue = "ERROR";
		codeText.text = "ERROR";
		Invoke("DelAll", delay);
	}

	void Update () 
	{
		codeText.text = codeTextValue;
	}

}