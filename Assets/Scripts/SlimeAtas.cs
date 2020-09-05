using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAtas : MonoBehaviour
{
	Animator anim;
	GameObject player;
	
	void Start()
	{
		anim = transform.parent.GetComponent<Animator>();
		player = GameObject.Find("Player");
	}
	
	void OnTriggerEnter2D (Collider2D target)
	{
		Collider2D parentCollider = gameObject.GetComponentInParent<PolygonCollider2D>();
		Collider2D playerCollider = player.GetComponent<BoxCollider2D>();
		
		if (target.gameObject.tag == "Player")
		{
			transform.parent.tag = "Untagged";
			Physics2D.IgnoreCollision(parentCollider, playerCollider);
			GetComponent<AudioSource>().Play();
			anim.SetBool("isDestroyed", true);
		}
	}
}
