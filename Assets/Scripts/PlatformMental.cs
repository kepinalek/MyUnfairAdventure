using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMental : MonoBehaviour
{
	GameObject player;
	Rigidbody2D rb;
	PlayerScript playerScript;
	float force = 700f;
	bool isCollided = false;
	
	void Start()
	{
		player = GameObject.Find("Player");
		rb = player.GetComponent<Rigidbody2D>();
		playerScript = player.GetComponent<PlayerScript>();
		transform.GetChild(0).gameObject.SetActive(false);
	}
	
	void Update()
	{
		if (isCollided)
		{
			playerScript.inputEnabled = false;
			rb.AddForce(Vector2.left * force * Time.deltaTime);
		}
	}

    void OnCollisionEnter2D(Collision2D target)
	{
		isCollided = true;
		transform.GetChild(0).gameObject.SetActive(true);
		transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = false;
		transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().enabled = false;
	}
}
