using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
	bool isCollided;
	public float speed = 20f;

    // Update is called once per frame
    void Update()
    {
        if (isCollided)
		{
			transform.position += new Vector3(0, speed * Time.deltaTime, 0);
		}
    }
	
	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.gameObject.tag == "Player")
		{
			isCollided = true;
			GetComponent<AudioSource>().Play();
		}
	}
}
