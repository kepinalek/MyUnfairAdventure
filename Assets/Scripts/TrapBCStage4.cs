using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBCStage4 : MonoBehaviour
{
	GameObject spike, tile1, tile2, jatuh;
	TrapBCStage4_1 scriptTile1;
	TrapBCStage4_2 scriptTile2;
	PlatformJatuhBawah scriptJatuh;
	Rigidbody2D rb;
	bool on = true;
	
    // Start is called before the first frame update
    void Start()
    {
		spike = gameObject.transform.GetChild(0).gameObject;
		tile1 = GameObject.Find("TrapBCStage4_1");
		tile2 = GameObject.Find("TrapBCStage4_2");
		jatuh = GameObject.Find("TrapBCStage4_jatuh");
		
		spike.SetActive(false);
		
		scriptTile1 = tile1.GetComponent<TrapBCStage4_1>();
		scriptTile2 = tile2.GetComponent<TrapBCStage4_2>();
		scriptJatuh = jatuh.GetComponent<PlatformJatuhBawah>();
    }
	
	void OnCollisionEnter2D (Collision2D target)
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
		
		if (target.gameObject.tag == "Player")
		{
			if (on)
			{
				rb.AddForce(new Vector2(1.5f, 2) * 300);
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -90), Time.deltaTime * 10);
			}
		}
		
		if (target.gameObject == tile1)
		{
			rb.AddForce(new Vector2(1.5f, 2) * 150);
			// transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -90), Time.deltaTime * 10);
			on = false;
		}
		
		if (target.gameObject == tile2)
		{
			rb.AddForce(new Vector2(1.5f, 2) * 150);
		}
	}
	
	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.gameObject.tag == "Player")
		{
			Destroy(gameObject.GetComponent<CapsuleCollider2D>());
			spike.SetActive(true);
			
			scriptTile1.on = true;
			scriptTile2.on = true;
			scriptJatuh.on = true;
		}
	}
}
