using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap5B1 : MonoBehaviour
{
	Trap5B parent;
	
	void Start()
	{
		parent = GetComponentInParent<Trap5B>();
	}
	
    IEnumerator OnTriggerEnter2D(Collider2D target)
	{
		if (target.gameObject.tag == "Player")
		{
			parent.down = true;
			parent.rise = true;
			
			yield return new WaitForSeconds(2.25f);
			parent.rise = false;
		}
	}
	
	void OnTriggerExit2D(Collider2D target)
	{
		if (target.gameObject.tag == "Player")
			parent.down = false;
	}
}
