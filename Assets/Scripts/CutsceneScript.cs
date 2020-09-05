using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScript : MonoBehaviour
{
	GameObject dialog;
	
	void Awake ()
	{
		dialog = GameObject.Find("Dialog");
		dialog.SetActive(false);
	}
	
	void OnTriggerEnter2D (Collider2D target)
	{
		dialog.SetActive(true);
	}
}
