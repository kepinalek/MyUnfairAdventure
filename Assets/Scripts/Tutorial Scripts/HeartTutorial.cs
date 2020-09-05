using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartTutorial : MonoBehaviour
{
	AudioSource hitSound;
	
	void Start()
	{
		hitSound = transform.parent.gameObject.transform.GetChild(1).gameObject.GetComponent<AudioSource>();
	}
	
    void OnTriggerEnter2D (Collider2D target)
	{
		if (target.gameObject.tag == "Player")
		{
			GameObject.Find("Canvas").GetComponent<TutorialScript>().heartHitted = true;
			
			if (hitSound != null)
				hitSound.Play();
			SaveSystem.SetInt("Live", SaveSystem.GetInt("Live") + 1);
				
			Destroy(gameObject);
		}
	}
}
