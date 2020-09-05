using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap5A : MonoBehaviour
{
    public bool on = false, fall = false;
	Rigidbody2D rb;
	public float waitTime = 1f, speed = 3f;
	public GameObject leftTrap;
	Trap5A script;
	
	void Start()
	{
		if (leftTrap != null)
			script = leftTrap.GetComponent<Trap5A>();
	}

    IEnumerator OnTriggerEnter2D(Collider2D target)
	{
		if (on)
		{
			if (target.gameObject.tag == "Player")
			{
				fall = true;
				
				if (leftTrap != null)
					script.on = true;
				
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
					rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
					rb.gravityScale = speed;
					childrenList[i].tag = "Deadly";
				}
				
				GetComponent<AudioSource>().Play();
			
				Destroy(gameObject.GetComponent<BoxCollider2D>());
			
				yield return new WaitForSeconds(waitTime);
			
				for (int i = 0; i < childrenList.Count; i++)
				{
					childrenList[i].tag = "Untagged";
					Destroy(childrenList[i].GetComponent<Rigidbody2D>());
				}
			}
		}
	}
}
