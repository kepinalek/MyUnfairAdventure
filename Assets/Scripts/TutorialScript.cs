using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
	GameObject child2, child3, child4, child5;
	public bool itemBoxHitted, heartHitted;
	
    // Start is called before the first frame update
    void Start()
    {
        child2 = transform.GetChild(2).gameObject;
        child3 = transform.GetChild(3).gameObject;
        child4 = transform.GetChild(4).gameObject;
        child5 = transform.GetChild(5).gameObject;
		
		child3.SetActive(false);
		child4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (itemBoxHitted)
		{
			child2.SetActive(false);
			child3.SetActive(true);
			child4.SetActive(false);
		}
		
		if (heartHitted)
		{
			child2.SetActive(false);
			child3.SetActive(false);
			child4.SetActive(true);
		}
		
		if (GameObject.Find("Slime") == null)
			child5.SetActive(false);
    }
}
