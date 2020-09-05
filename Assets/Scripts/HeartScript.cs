using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
	public bool addLive = true;
	AudioSource hitSound;
	
	void Start ()
	{
		hitSound = transform.parent.gameObject.transform.GetChild(1).gameObject.GetComponent<AudioSource>();
	}
	
    void OnTriggerEnter2D (Collider2D target)
	{
		if (target.gameObject.tag == "Player")
		{
			if (addLive)
			{
				if (hitSound != null)
					hitSound.Play();
				SaveSystem.SetInt("Live", SaveSystem.GetInt("Live") + 1);
				SaveSystem.SetBool("ItemBoxOn", false);
			}
			Destroy(gameObject);
		}
	}
}
