using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox3 : MonoBehaviour
{
    Animator anim;
	GameObject child;
	Rigidbody2D rb;
	
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
		child = gameObject.transform.GetChild(0).gameObject;
    }
	
	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.gameObject.tag == "Player")
		{
			anim.SetBool("isHitted", true);
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
			}
		}
	}
}
