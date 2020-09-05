using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyedPlayerBig : MonoBehaviour
{
	public GameObject bodyPart;
	
    void OnCollisionEnter2D (Collision2D target)
	{
		if (target.gameObject.tag == "PlayerBig")
		{
			Destroy(gameObject);
			GameObject.Find("BlockDestroyedSound").GetComponent<AudioSource>().Play();
			
			for (int i = 0; i < 15; i++)
			{
				transform.TransformPoint(0, -100, 0);
				GameObject clone = Instantiate(bodyPart, transform.position, Quaternion.identity) as GameObject;
				clone.GetComponent<Rigidbody2D>().AddForce(Vector3.right * Random.Range(-50, 50));
				clone.GetComponent<Rigidbody2D>().AddForce(Vector3.up * Random.Range(100, 400));
			}
		}
	}
}
