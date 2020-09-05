using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
	Text txt;
	
    // Start is called before the first frame update
    void Start()
    {
		txt = gameObject.GetComponent<Text>();
    }
	
	void Update()
	{
		txt.text = "x " + SaveSystem.GetInt("Live");
	}
}
