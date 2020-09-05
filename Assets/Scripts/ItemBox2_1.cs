using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox2_1 : MonoBehaviour
{
    Animator anim;
	Rigidbody2D rb;
	Collider2D col;
	AudioSource hitSound;
	
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
		col = transform.GetChild(0).GetComponent<PolygonCollider2D>();
		col.enabled = false;
		hitSound = GetComponent<AudioSource>();
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
			
			rb = transform.GetChild(0).GetComponent<Rigidbody2D>();
			rb.constraints = ~RigidbodyConstraints2D.FreezePosition;
			col.enabled = true;
			transform.GetChild(0).transform.parent = null;
		}
	}
}
