using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDStage4 : MonoBehaviour
{
	Rigidbody2D rb;
	public float force = 800f;
	
	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	IEnumerator OnTriggerEnter2D (Collider2D target)
	{
		if (target.gameObject.tag == "Player")
		{
			rb.AddForce(Vector2.right * force);
			GetComponent<AudioSource>().Play();
			yield return new WaitForSeconds(0.5f);
			rb.constraints = RigidbodyConstraints2D.FreezePositionX | ~RigidbodyConstraints2D.FreezePositionY;
			rb.AddForce(Vector2.up * force);
			GetComponent<AudioSource>().Play();
			yield return new WaitForSeconds(0.18f);
			rb.constraints = ~RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
			yield return new WaitForSeconds(0.32f);
			rb.AddForce(Vector2.left * force);
			GetComponent<AudioSource>().Play();
			yield return new WaitForSeconds(0.5f);
			rb.constraints = RigidbodyConstraints2D.FreezePositionX | ~RigidbodyConstraints2D.FreezePositionY;
			rb.AddForce(Vector2.down * force);
			GetComponent<AudioSource>().Play();
			gameObject.tag = "Deadly";
			yield return new WaitForSeconds(0.5f);
			Destroy(rb);
			gameObject.tag = "Untagged";
		}
	}
}
