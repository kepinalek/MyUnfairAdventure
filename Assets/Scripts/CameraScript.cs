using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
	public bool playerExist = true;
    GameObject player;
    private Vector3 offset;  
	
    // Use this for initialization
    void Start () 
    {
		if (playerExist)
		{
			player = GameObject.Find("Player");
			CamFollowPlayer();
		}
    }

	void Update()
	{
		if (playerExist)
			CamFollowPlayer();
	}
	
	void CamFollowPlayer()
	{
		Vector3 setPosition = transform.position;
		setPosition.x = player.transform.position.x;
		transform.position = setPosition;
	}
}
