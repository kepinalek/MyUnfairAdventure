using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogScript : MonoBehaviour
{
	public TextMeshProUGUI textDisplay;
	GameObject button, heartLogo, HP;
	private int index;
	public float typingSpeed = 0.02f;
	Coroutine co;
	
	[TextArea]
	public string[] sentences;
	
	void Start()
	{
		if (SaveSystem.GetBool("DialogOn"))
		{
			textDisplay = gameObject.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
			button = GameObject.Find("Buttons");
			heartLogo = GameObject.Find("HeartLogo");
			HP = GameObject.Find("HPText");
			
			button.SetActive(false);
			heartLogo.SetActive(false);
			HP.SetActive(false);
			textDisplay.text = "";
		
			co = StartCoroutine(Type());
		}
		else gameObject.SetActive(false);
	}
	
    IEnumerator Type()
	{
		foreach (char letter in sentences[index].ToCharArray())
		{
			textDisplay.text += letter;
			yield return new WaitForSeconds(typingSpeed);
		}
	}
	
	public void NextSentence()
	{
		if (index < sentences.Length - 1)
		{
			StopCoroutine(co);
			index++;
			textDisplay.text = "";
			co = StartCoroutine(Type());
		}
		else
		{
			gameObject.SetActive(false);
			button.SetActive(true);
			heartLogo.SetActive(true);
			HP.SetActive(true);
			SaveSystem.SetBool("DialogOn", false);
		}
	}
}
