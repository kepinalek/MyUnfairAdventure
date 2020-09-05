using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapFStage4 : MonoBehaviour
{
	Collider2D col;
	Rigidbody2D rb;
	
    // Start is called before the first frame update
    void Start()
    {
		col = gameObject.GetComponent<EdgeCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
	
	IEnumerator OnTriggerEnter2D (Collider2D target)
	{
		if (target.gameObject.tag == "Player")
		{
			col.enabled = false;
			yield return new WaitForSeconds(0.1f);
			
			gameObject.tag = "Deadly";
			yield return new WaitForSeconds(0.3f);
			rb.AddForce(Vector2.left * 1500f);
			GetComponent<AudioSource>().Play();
			
			yield return new WaitForSeconds(0.15f);
			rb.velocity = Vector2.zero;
			rb.AddForce(Vector2.right * 100f);
			
			yield return new WaitForSeconds(2);
			gameObject.tag = "Untagged";
			col.enabled = true;
		}
	}
}
