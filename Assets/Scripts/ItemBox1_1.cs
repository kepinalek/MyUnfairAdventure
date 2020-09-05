using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox1_1 : MonoBehaviour
{
    Animator anim;
	public AudioSource hitSound;
	
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
		hitSound = GetComponent<AudioSource>();
		
		if (!SaveSystem.GetBool("ItemBoxOn"))
		{
			anim.SetBool("isHitted", true);
			Destroy(gameObject.GetComponent<EdgeCollider2D>());
		}
    }
	
	IEnumerator OnTriggerEnter2D (Collider2D target)
	{
		if (target.gameObject.tag == "Player")
		{
			anim.SetBool("isHitted", true);
			hitSound.Play();
			Destroy(gameObject.GetComponent<EdgeCollider2D>());
			
			for (int i = 0; i < 10; i++)
			{
				transform.GetChild(0).transform.position += new Vector3(0, 0.07f, 0);
				yield return new WaitForSeconds(0.03f);
			}
			
			transform.GetChild(0).transform.parent = null;
		}
	}
}
