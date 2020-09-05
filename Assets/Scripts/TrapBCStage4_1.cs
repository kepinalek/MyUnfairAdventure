using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBCStage4_1 : MonoBehaviour
{
	public bool on = false;
	GameObject trap;
	Rigidbody2D rb;
	public float force = 250f;
    public GameObject bodyPart;
	public bool isDestroyed;
	
	void Start()
	{
		trap = GameObject.Find("TrapBCStage4");
	}
	
    void OnCollisionEnter2D (Collision2D target)
	{
		if (target.gameObject.tag == "Deadly")
		{
			OnExplode();
		}
	}
	
	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.gameObject.tag == "Player")
		{
			if (on)
			{
				trap.tag = "Deadly";
				rb = trap.AddComponent<Rigidbody2D>();
				rb.gravityScale = 5;
				rb.AddForce(new Vector2(-1, 2) * force);
				on = false;
			}
		}
	}
	
	void OnExplode()
	{
		isDestroyed = true;
		for (int i = 0; i < 15; i++)
		{
			transform.TransformPoint(0, -100, 0);
			GameObject clone = Instantiate(bodyPart, transform.position, Quaternion.identity) as GameObject;
			clone.GetComponent<Rigidbody2D>().AddForce(Vector3.right * Random.Range(-50, 50));
			clone.GetComponent<Rigidbody2D>().AddForce(Vector3.up * Random.Range(100, 400));
		}
		Destroy(gameObject);
	}
}
