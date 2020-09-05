using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
	Renderer render;
    Rigidbody2D rb;
	public float speed = 15f;
	Animator anim;
	bool playSound = true;
	
    // Start is called before the first frame update
    void Start()
    {
		render = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (render.isVisible)
		{
			rb.velocity = Vector2.left * speed;
			if (playSound)
			{
				GetComponent<AudioSource>().Play();
				playSound = false;
			}
		}
    }
	
	IEnumerator OnCollisionEnter2D (Collision2D target)
	{
		if (target.gameObject.tag != "Player")
		{
			anim.SetBool("isExplode", true);
			yield return new WaitForSeconds(0.3f);
			Destroy(gameObject);
		}
	}
}
