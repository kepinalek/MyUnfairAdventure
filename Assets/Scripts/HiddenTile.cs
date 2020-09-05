using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenTile : MonoBehaviour
{
	SpriteRenderer spriteRender;
	PlatformEffector2D platformEffector;
	
    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
		platformEffector = GetComponent<PlatformEffector2D>();
		spriteRender.enabled = false;
    }
	
	void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.tag == "Player")
        {
            spriteRender.enabled = true;
			platformEffector.enabled = false;
			Destroy(this.gameObject.GetComponentInChildren<HiddenTileChild>());
        }
	}
}
