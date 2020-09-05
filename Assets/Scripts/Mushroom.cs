using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
	GameObject player;
    Rigidbody2D rb;
	bool isCollided;
	
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }
	
	void Update()
	{
		if (isCollided)
			rb.velocity = new Vector2(transform.localScale.x, 0) * 1;
	}
	
	void OnCollisionEnter2D (Collision2D target)
	{
		if (target.gameObject.tag == "Ground")
			isCollided = true;
		else Destroy(gameObject);
	}
	
	void OnCollisionExit2D (Collision2D target)
	{
		isCollided = false;
	}
}
