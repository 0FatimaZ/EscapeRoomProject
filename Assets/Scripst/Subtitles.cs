using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public struct SubtitleText
{
    public float time;
    public string text;
}

public class Subtitles : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;

    public SubtitleText[] sentences;
    int index;

    public float typingSpeed;
    public GameObject DialogPanel;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(texting());
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    /*IEnumerator Type()
    {
        foreach (var letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }*/



    public void nextSentence()
    {

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(texting());

        }
        else
        {
            textDisplay.gameObject.SetActive(false);
            textDisplay.text = "";
        }
    }

    IEnumerator texting()
    {
        textDisplay.text = sentences[index].text;
        yield return new WaitForSeconds(sentences[index].time);
        nextSentence();
    }
}
