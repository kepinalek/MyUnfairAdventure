using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeJump : MonoBehaviour
{
	void OnTriggerExit2D (Collider2D target)
	{
		if (target.gameObject.tag == "Player")
		{
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * 700f);
			Destroy(this);
		}
	}
}
