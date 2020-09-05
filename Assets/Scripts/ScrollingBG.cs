using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
	public float scrollSpeed = 5f, repeatPos = 20f;
	Vector2 startPos;
	
    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, repeatPos);
		transform.position = startPos + Vector2.left * newPos;
    }
}
