using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	Text GameOverTxt, MessageTxt;
	GameObject TryAgain, MainMenu, LvlUpTxt;
	
    // Start is called before the first frame update
    void Start()
    {
		Destroy(GameObject.FindWithTag("BGM"));
		
		GameOverTxt = GameObject.Find("Text").GetComponent<Text>();
		MessageTxt = GameObject.Find("Text (1)").GetComponent<Text>();
		TryAgain = GameObject.Find("TryAgainBtn");
		MainMenu = GameObject.Find("MainMenuBtn");
		LvlUpTxt = GameObject.Find("LevelUpTxt");
		
		LvlUpTxt.SetActive(false);
		
		TryAgain.GetComponent<Button>().onClick.AddListener(TryAgainPressed);
		MainMenu.GetComponent<Button>().onClick.AddListener(MainMenuPressed);
		
		SaveSystem.SetInt("Checkpoint", 0);
		SaveSystem.SetBool("ItemBoxOn", true);
		
		if (SaveSystem.GetInt("Death") % 3 == 0 && SaveSystem.GetInt("Death") != 0 && SaveSystem.GetBool("CheckDeath"))
		{
			SaveSystem.SetInt("Level", SaveSystem.GetInt("Level") + 1);
			LvlUpTxt.SetActive(true);
			SaveSystem.SetBool("CheckDeath", false);
		}
		else if (SaveSystem.GetInt("Death") % 3 != 0)
				SaveSystem.SetBool("CheckDeath", true);
		
		SaveSystem.SetInt("Live", 10 + SaveSystem.GetInt("Level") - 1);
		
		StartCoroutine(FadeIn());
    }
	
	IEnumerator FadeIn()
	{
		for (float i = 0; i <= 1; i += Time.deltaTime)
		{
			GameOverTxt.color = new Color(1, 1, 1, i);
			MessageTxt.color = new Color(1, 1, 1, i);
			TryAgain.GetComponent<Image>().color = new Color(1, 1, 1, i);
			TryAgain.GetComponentInChildren<Text>().color = new Color(0, 0, 0, i);
			MainMenu.GetComponent<Image>().color = new Color(1, 1, 1, i);
			MainMenu.GetComponentInChildren<Text>().color = new Color(0, 0, 0, i);
			LvlUpTxt.GetComponent<Text>().color = new Color(1, 1, 1, i);
			yield return null;
		}
	}

    void TryAgainPressed()
	{
		SceneManager.LoadScene(SaveSystem.GetString("Stage"));
	}
	
	void MainMenuPressed()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
