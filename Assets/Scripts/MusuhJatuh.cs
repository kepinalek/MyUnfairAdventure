using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusuhJatuh : MonoBehaviour
{
	Rigidbody2D rb;
	
	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.gameObject.tag == "Player")
		{
			int children = transform.childCount;
			
			for (int i = 0; i < children; i++)
			{
				rb = transform.GetChild(i).GetComponent<Rigidbody2D>();
				rb.constraints = ~RigidbodyConstraints2D.FreezePosition;
			}
		}
	}
}