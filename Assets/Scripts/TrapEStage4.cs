using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapEStage4 : MonoBehaviour
{
	Collider2D col;
	public GameObject fireball;
	GameObject child0, child1, child2;
	Rigidbody2D rb0, rb1, rb2;
	public float force = 300f;
	bool isOn, isMoving, isRotated;
	
    void Start()
    {
		col = gameObject.GetComponent<BoxCollider2D>();
		child0 = transform.GetChild(0).gameObject;
		child1 = transform.GetChild(1).gameObject;
		child2 = transform.GetChild(2).gameObject;
		rb0 = child0.GetComponent<Rigidbody2D>();
		rb1 = child1.GetComponent<Rigidbody2D>();
		rb2 = child2.GetComponent<Rigidbody2D>();
    }
	
	void Update()
	{
		if (isMoving)
		{
			if (rb0.velocity.y < 0)
			{
				child0.transform.Rotate(180, 0, 0);
				child1.transform.Rotate(180, 0, 0);
				child2.transform.Rotate(180, 0, 0);
				isMoving = false;
				isRotated = true;
			}
		}
	}
	
	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.gameObject == fireball)
			isOn = true;
		
		if (isOn)
		{
			if (target.gameObject.tag == "Player")
			{
				GetComponent<AudioSource>().Play();
			
				col.enabled = false;
				rb0.constraints = ~RigidbodyConstraints2D.FreezePositionY;
				rb1.constraints = ~RigidbodyConstraints2D.FreezePositionY;
				rb2.constraints = ~RigidbodyConstraints2D.FreezePositionY;
				rb0.AddForce(Vector2.up * force);
				rb1.AddForce(Vector2.up * force);
				rb2.AddForce(Vector2.up * force);
				isMoving = true;
			}
		}
	}
	
	IEnumerator OnTriggerExit2D (Collider2D target)
	{
		if (target.gameObject == child0)
		{
			if (isRotated)
			{
				rb0.constraints = RigidbodyConstraints2D.FreezePositionY;
				rb1.constraints = RigidbodyConstraints2D.FreezePositionY;
				rb2.constraints = RigidbodyConstraints2D.FreezePositionY;
				child0.transform.Rotate(180, 0, 0);
				child1.transform.Rotate(180, 0, 0);
				child2.transform.Rotate(180, 0, 0);
				isRotated = false;
				
				yield return new WaitForSeconds(0.5f);
				
				if (GetComponent<Renderer>().isVisible)
					GetComponent<AudioSource>().Play();
				rb0.constraints = ~RigidbodyConstraints2D.FreezePositionY;
				rb1.constraints = ~RigidbodyConstraints2D.FreezePositionY;
				rb2.constraints = ~RigidbodyConstraints2D.FreezePositionY;
				rb0.AddForce(Vector2.up * force);
				rb1.AddForce(Vector2.up * force);
				rb2.AddForce(Vector2.up * force);
				isMoving = true;
			}
		}
	}
}
