using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox2_2 : MonoBehaviour
{
    Animator anim;
	GameObject child;
	
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
		child = gameObject.transform.GetChild(0).gameObject;
		child.SetActive(false);
    }
	
	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.gameObject.tag == "Player")
		{
			anim.SetBool("isHitted", true);
			Destroy(gameObject.GetComponent<EdgeCollider2D>());
			child.SetActive(true);
		}
	}
}
