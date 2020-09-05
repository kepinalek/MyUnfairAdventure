using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenTileChild : MonoBehaviour
{
	GameObject player;
	
	void Start()
	{
		player = GameObject.Find("Player");
	}
	
	IEnumerator OnTriggerEnter2D (Collider2D target)
	{
		Collider2D parentCollider = gameObject.GetComponentInParent<BoxCollider2D>();
		Collider2D parentCollider2 = gameObject.GetComponentInParent<EdgeCollider2D>();
		Collider2D playerCollider = player.GetComponent<BoxCollider2D>();
		
		if (target.gameObject.tag == "Player")
		{
			Physics2D.IgnoreCollision(parentCollider, playerCollider);
			Physics2D.IgnoreCollision(parentCollider, parentCollider2);
			yield return new WaitForSeconds(0.25f);
			Physics2D.IgnoreCollision(parentCollider, playerCollider, false);
			Physics2D.IgnoreCollision(parentCollider, parentCollider2, false);
		}
	}
}
