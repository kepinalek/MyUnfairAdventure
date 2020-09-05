using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog2Script : MonoBehaviour
{
	public TextMeshProUGUI textDisplay;
	GameObject button, heartLogo, HP;
	Button nextBtn;
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
			nextBtn = gameObject.transform.GetChild(1).GetComponent<Button>();
			nextBtn.onClick.AddListener(nextBtnPressed);
			
			button.SetActive(false);
			heartLogo.SetActive(false);
			HP.SetActive(false);
			textDisplay.text = "";
		
			StartCoroutine(main());
		}
		else gameObject.SetActive(false);
	}
	
	IEnumerator main ()
	{
		for (float i = 0; i <= 1; i += 0.25f)
		{
			transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color(0, 0, 0, i);
			yield return new WaitForSeconds(0.25f);
		}
		
		co = StartCoroutine(Type());
	}
	
	void nextBtnPressed()
	{
		StartCoroutine(NextSentence());
	}
	
    IEnumerator Type()
	{
		foreach (char letter in sentences[index].ToCharArray())
		{
			textDisplay.text += letter;
			yield return new WaitForSeconds(typingSpeed);
		}
	}
	
	IEnumerator NextSentence()
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
			textDisplay.text = "";
			
			for (float i = 1; i >= 0; i -= 0.25f)
			{
				transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color(0, 0, 0, i);
				yield return new WaitForSeconds(0.25f);
			}
		
			gameObject.SetActive(false);
			button.SetActive(true);
			heartLogo.SetActive(true);
			HP.SetActive(true);
			SaveSystem.SetBool("DialogOn", false);
		}
	}
}
