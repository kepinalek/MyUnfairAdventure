using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenTileDestroy : MonoBehaviour
{
    public GameObject bodyPart;
	
	void OnTriggerEnter2D (Collider2D target)
	{
		Destroy(gameObject);
			
		for (int i = 0; i < 15; i++)
		{
			transform.TransformPoint(0, -100, 0);
			GameObject clone = Instantiate(bodyPart, transform.position, Quaternion.identity) as GameObject;
			clone.GetComponent<Rigidbody2D>().AddForce(Vector3.right * Random.Range(-50, 50));
			clone.GetComponent<Rigidbody2D>().AddForce(Vector3.up * Random.Range(100, 400));
		}
	}
}
