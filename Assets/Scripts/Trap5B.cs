using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap5B : MonoBehaviour
{
	PlayerScript player;
	Rigidbody2D rb;
	public bool up, down, rise;
	
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (up && down)
			StartCoroutine(player.OnExplode());
		
		if (rise)
			StartCoroutine(GoingUp());
    }
	
	void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.tag == "Player")
			up = true;
	}
	
	void OnCollisionExit2D(Collision2D target)
	{
		if (target.gameObject.tag == "Player")
			up = false;
	}
	
	IEnumerator GoingUp()
	{
			List<GameObject> childrenList = new List<GameObject>();
			Transform[] children = GetComponentsInChildren<Transform>(true);
			
			for (int i = 0; i < children.Length; i++)
			{
				Transform child = children[i];
				if (child != transform)
					childrenList.Add(child.gameObject);
			}
		
			for (int i = 0; i < childrenList.Count; i++)
			{
				childrenList[i].transform.position = childrenList[i].transform.position + Vector3.up * Time.deltaTime * 3;
			}
			
			yield return new WaitForSeconds(5f);
		}
}
