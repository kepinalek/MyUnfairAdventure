using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformJatuhAtas : MonoBehaviour
{
	Rigidbody2D rb;
	public float fallSpeed = 5f;

    void OnCollisionEnter2D(Collision2D target)
	{
		Fall();
	}
	
	void OnTriggerEnter2D (Collider2D target)
	{
		Fall();
	}
	
	void Fall()
	{
		rb = gameObject.AddComponent<Rigidbody2D>();
		rb.gravityScale = fallSpeed;
		
		List<GameObject> childrenList = new List<GameObject>();
		Transform[] children = GetComponentsInChildren<Transform>(true);
			
		for (int i = 0; i < children.Length; i++)
		{
			Transform child = children[i];
			if (child != transform)
				childrenList.Add(child.gameObject);
		}
		
		for (int i = 0; i < childrenList.Count; i++)
		{
			rb = childrenList[i].AddComponent<Rigidbody2D>();
			rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			rb.gravityScale = fallSpeed;
		}
	}
}
