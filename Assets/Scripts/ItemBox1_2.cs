using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox1_2 : MonoBehaviour
{
	Animator anim;
	public GameObject slime;
	AudioSource hitSound;
	
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
		hitSound = GetComponent<AudioSource>();
    }
	
	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.gameObject.tag == "Player")
		{
			anim.SetBool("isHitted", true);
			hitSound.Play();
			int children = transform.childCount;
			
			for (int i = 0; i < children; i++)
			{
				Instantiate(slime, transform.GetChild(i).transform.position, transform.GetChild(i).transform.rotation);
				Destroy(transform.GetChild(i).gameObject);
			}
		}
	}
}
