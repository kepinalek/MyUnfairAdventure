using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformJatuhBawah : MonoBehaviour
{
	public bool on = true;
	Rigidbody2D rb;
	public float waitTime = 0.5f;

    IEnumerator OnTriggerEnter2D(Collider2D target)
	{
		if (on)
		{
			if (target.gameObject.tag == "Player")
			{
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
					rb.gravityScale = 5;
					childrenList[i].tag = "Deadly";
				}
			
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
