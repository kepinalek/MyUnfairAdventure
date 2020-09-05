using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotateScript : MonoBehaviour
{
	GameObject player;
	Rigidbody2D rb;
	bool isCollided = false;
	PlayerScript playerScript;
	
	// [SerializeField]
	float rotateDegree = -90f, rotateSpeed = 10f, xForce = 3f, yForce = 300f/* , force = 300f */;
	
	void Start()
	{
		player = GameObject.Find("Player");
		rb = player.GetComponent<Rigidbody2D>();
		playerScript = player.GetComponent<PlayerScript>();
	}
	
	void Update()
	{
		if (isCollided)
		{
			playerScript.inputEnabled = false;
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, rotateDegree), Time.deltaTime * rotateSpeed);
			rb.AddForce(Vector2.right * xForce);
		}
	}
	
	void FixedUpdate()
	{
		if (isCollided)
		{
		}
	}
	
    void OnTriggerEnter2D (Collider2D target)
	{
		isCollided = true;
		rb.AddForce(Vector2.up * yForce);
		player.transform.position += new Vector3(0, 0.1f, 0);
		// player.transform.Translate((yForce * new Vector2 (Mathf.Cos(45), Mathf.Sin(45))) * Time.deltaTime);
		// player.transform.position += new Vector3(xForce * Mathf.Cos(45), yForce * Mathf.Sin(45), 0);
		// rb.AddForce(new Vector2(force * Mathf.Cos(45), force * Mathf.Sin(45)));
	}
}
