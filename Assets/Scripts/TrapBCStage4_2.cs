using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBCStage4_2 : MonoBehaviour
{
    public bool on = false, isActive;
	GameObject trap, tile1;
	TrapBCStage4_1 scriptTile1;
	Rigidbody2D rb;
	public float force = 250f;
    public GameObject bodyPart;
	
	void Start()
	{
		trap = GameObject.Find("TrapBCStage4");
		tile1 = GameObject.Find("TrapBCStage4_1");
		scriptTile1 = tile1.GetComponent<TrapBCStage4_1>();
	}
	
	void Update()
	{
		if (isActive)
		if (scriptTile1.isDestroyed == true)
		{
			trap.tag = "Deadly";
				rb = trap.GetComponent<Rigidbody2D>();
				rb.constraints = RigidbodyConstraints2D.FreezePosition;
				rb.constraints = ~RigidbodyConstraints2D.FreezePosition;
				rb.AddForce(new Vector2(-1.5f, 0.5f) * force);
				on = false;
				scriptTile1.isDestroyed = false;
		}
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
				isActive = true;
			}
		}
	}
	
	void OnExplode()
	{
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
