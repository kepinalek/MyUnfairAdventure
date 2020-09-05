using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
	public static float timer;
	bool timerRunning;
	public Button stage1Button;

	void Awake ()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag("Script");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
	}
	
	void Start ()
	{
		timer = 60f;
		stage1Button.onClick.AddListener(isClicked);
	}
	
	void isClicked ()
	{
		timerRunning = true;
		gameObject.tag = "Script";
	}

    // Update is called once per frame
    void Update()
    {
		if (timerRunning && timer > 0)
		{
			timer -= Time.deltaTime;
		}
		else timerRunning = false;
    }
}
