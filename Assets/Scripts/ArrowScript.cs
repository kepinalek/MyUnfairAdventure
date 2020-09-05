using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    GameObject player;
	PlayerScript playerScript;
    private Vector3 offset;  
	
    void Start () 
    {
		GetComponent<SpriteRenderer>().enabled = false;
		player = GameObject.Find("Player");
		playerScript = player.GetComponent<PlayerScript>();
		FollowPlayer();
		StartCoroutine(moveDown());
    }

	void Update()
	{
		if (player.GetComponent<Renderer>().isVisible || playerScript.dead || playerScript.kenaJamur)
			GetComponent<SpriteRenderer>().enabled = false;
		else GetComponent<SpriteRenderer>().enabled = true;
		
		FollowPlayer();
	}
	
	void FollowPlayer()
	{
		Vector3 setPosition = transform.position;
		setPosition.x = player.transform.position.x;
		transform.position = setPosition;
	}
	
	IEnumerator moveDown()
	{
		yield return new WaitForSeconds(0.5f);
		transform.position -= new Vector3(0, 2, 0);
	}
}
