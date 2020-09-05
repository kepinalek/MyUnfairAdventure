using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTile : MonoBehaviour
{
    void OnCollisionEnter2D (Collision2D target)
	{
		if (target.gameObject.tag == "Player")
			Destroy(gameObject);
	}
}
