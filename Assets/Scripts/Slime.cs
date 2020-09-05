using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
	
    public float speed = .5f;
    Rigidbody2D rb;
	Renderer render;
	public bool isCollided, isHitMushroom = false, isLockded = true;

	// Use this for initialization
	void Start ()
	{
        rb = GetComponent<Rigidbody2D>();
		render = GetComponent<Renderer>();
    }
	
	void Update()
	{
		if (render.isVisible)
		{
			if (!isHitMushroom)
			{
				if (isCollided)
				{
					isLockded = false;
					rb.velocity = new Vector2(transform.localScale.x, 0) * speed;
				}
			}
		}
		else if (isLockded)
			rb.velocity = Vector2.zero;
	}
	
	void OnCollisionEnter2D (Collision2D target)
	{
		if (target.gameObject.tag == "Ground")
			isCollided = true;
		
		if (target.gameObject.name == "Mushroom")
		{
			HitMushroom();
			isCollided = false;
			isHitMushroom = true;
		}
		
		if (target.gameObject.tag == "PlayerBig")
			Destroyed();
	}
	
	void OnCollisionExit2D (Collision2D target)
	{
		isCollided = false;
	}
	
	void HitMushroom()
	{
		gameObject.tag = "PlayerBig";
		transform.localScale *= 3;
	}
	
	void Destroyed()
	{
		Destroy(gameObject);
		//kepake di animation
	}
}