using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	Canvas home, stageSelect, sttng, ach, about;
	Button stageButton, settingButton, achievementButton, aboutButton, exitButton, tutorialButton, stage1, stage2, stage3, stage4, stage5, backStage, backSetting, backAchievement, backAbout, yesButton, noButton;
	Text txt;
	GameObject exitButtonPanel;
	GameObject logo;
	
    void Start()
    {
		Time.timeScale = 1;
		
		Destroy(GameObject.FindWithTag("BGM"));
		
		SaveSystem.SetInt("Checkpoint", 0);
		SaveSystem.SetBool("ItemBoxOn", true);
		
		if (SaveSystem.GetInt("Level") == 0)
		{
			SaveSystem.SetInt("Level", 1);
			SaveSystem.SetInt("Live", 10);
			SaveSystem.SetInt("Death", 0);
			SaveSystem.SetBool("CheckDeath", true);
			SaveSystem.SetBool("Stage1Cleared", false);
			SaveSystem.SetBool("Stage2Cleared", false);
			SaveSystem.SetBool("Stage3Cleared", false);
			SaveSystem.SetBool("Stage4Cleared", false);
		}
		
		SaveSystem.SetInt("Checkpoint", 0);
		SaveSystem.SetBool("ItemBoxOn", true);
		SaveSystem.SetBool("DialogOn", true);
		
		if (SaveSystem.GetInt("Death") % 3 == 0 && SaveSystem.GetInt("Death") != 0 && SaveSystem.GetBool("CheckDeath"))
		{
			SaveSystem.SetInt("Level", SaveSystem.GetInt("Level") + 1);
			SaveSystem.SetBool("CheckDeath", false);
		}
		else if (SaveSystem.GetInt("Death") % 3 != 0)
				SaveSystem.SetBool("CheckDeath", true);
		
		SaveSystem.SetInt("Live", 10 + SaveSystem.GetInt("Level") - 1);
		
		print("Level: " + SaveSystem.GetInt("Level"));
		print("Live: " + SaveSystem.GetInt("Live"));
		print("Death: " + SaveSystem.GetInt("Death"));
		
		txt = GameObject.Find("LevelTxt").GetComponent<Text>();
		txt.text = "Mastery " + SaveSystem.GetInt("Level");
		
		home = GameObject.Find("Home").GetComponent<Canvas>();
		stageSelect = GameObject.Find("Stage Select").GetComponent<Canvas>();
		sttng = GameObject.Find("Setting").GetComponent<Canvas>();
		ach = GameObject.Find("Achievement").GetComponent<Canvas>();
		about = GameObject.Find("About").GetComponent<Canvas>();
		
        stageButton = GameObject.Find("StageBtn").GetComponent<Button>();
        settingButton = GameObject.Find("SettingBtn").GetComponent<Button>();
        achievementButton = GameObject.Find("AchievementBtn").GetComponent<Button>();
        aboutButton = GameObject.Find("AboutBtn").GetComponent<Button>();
        backStage = GameObject.Find("StageBackBtn").GetComponent<Button>();
        backSetting = GameObject.Find("SettingBackBtn").GetComponent<Button>();
        backAchievement = GameObject.Find("AchievementBackBtn").GetComponent<Button>();
        backAbout = GameObject.Find("AboutBackBtn").GetComponent<Button>();
        tutorialButton = GameObject.Find("Tutorial").GetComponent<Button>();
        stage1 = GameObject.Find("Stage 1").GetComponent<Button>();
        stage2 = GameObject.Find("Stage 2").GetComponent<Button>();
        stage3 = GameObject.Find("Stage 3").GetComponent<Button>();
        stage4 = GameObject.Find("Stage 4").GetComponent<Button>();
        stage5 = GameObject.Find("Stage 5").GetComponent<Button>();
        exitButton = GameObject.Find("ExitBtn").GetComponent<Button>();
		exitButtonPanel = GameObject.Find("ExitPnl");
		yesButton = GameObject.Find("YesBtn").GetComponent<Button>();
		noButton = GameObject.Find("NoBtn").GetComponent<Button>();
		logo = GameObject.Find("Logo");
		
		home.gameObject.SetActive(true);
		stageSelect.gameObject.SetActive(false);
		sttng.gameObject.SetActive(false);
		ach.gameObject.SetActive(false);
		about.gameObject.SetActive(false);
		exitButtonPanel.gameObject.SetActive(false);
		
		stageButton.onClick.AddListener(stagePressed);
		settingButton.onClick.AddListener(settingPressed);
		achievementButton.onClick.AddListener(achievementPressed);
		aboutButton.onClick.AddListener(aboutPressed);
		backStage.onClick.AddListener(stageBackPressed);
		backSetting.onClick.AddListener(setingBackPressed);
		backAchievement.onClick.AddListener(achievementBackPressed);
		backAbout.onClick.AddListener(aboutBackPressed);
		tutorialButton.onClick.AddListener(tutorialPressed);
		stage1.onClick.AddListener(stage1Pressed);
		stage2.onClick.AddListener(stage2Pressed);
		stage3.onClick.AddListener(stage3Pressed);
		stage4.onClick.AddListener(stage4Pressed);
		stage5.onClick.AddListener(stage5Pressed);
		exitButton.onClick.AddListener(exitButtonPressed);
		yesButton.onClick.AddListener(yesPressed);
		noButton.onClick.AddListener(noPressed);
		
		if (SaveSystem.GetBool("Stage1Cleared"))
			stage2.interactable = true;
		else stage2.interactable = false;
		
		if (SaveSystem.GetBool("Stage2Cleared"))
			stage3.interactable = true;
		else stage3.interactable = false;
		
		if (SaveSystem.GetBool("Stage3Cleared"))
			stage4.interactable = true;
		else stage4.interactable = false;
		
		if (SaveSystem.GetBool("Stage4Cleared"))
			stage5.interactable = true;
		else stage5.interactable = false;
    }
	
	void stagePressed()
	{
		home.gameObject.SetActive(false);
		stageSelect.gameObject.SetActive(true);
		sttng.gameObject.SetActive(false);
		ach.gameObject.SetActive(false);
		about.gameObject.SetActive(false);
	}
	
	void settingPressed()
	{
		home.gameObject.SetActive(false);
		stageSelect.gameObject.SetActive(false);
		sttng.gameObject.SetActive(true);
		ach.gameObject.SetActive(false);
		about.gameObject.SetActive(false);
	}
	
	void achievementPressed()
	{
		home.gameObject.SetActive(false);
		stageSelect.gameObject.SetActive(false);
		sttng.gameObject.SetActive(false);
		ach.gameObject.SetActive(true);
		about.gameObject.SetActive(false);
	}
	
	void aboutPressed()
	{
		home.gameObject.SetActive(false);
		stageSelect.gameObject.SetActive(false);
		sttng.gameObject.SetActive(false);
		ach.gameObject.SetActive(false);
		about.gameObject.SetActive(true);
	}
	
	void stageBackPressed()
	{
		home.gameObject.SetActive(true);
		stageSelect.gameObject.SetActive(false);
		sttng.gameObject.SetActive(false);
		ach.gameObject.SetActive(false);
		about.gameObject.SetActive(false);
	}
	
	void setingBackPressed()
	{
		home.gameObject.SetActive(true);
		stageSelect.gameObject.SetActive(false);
		sttng.gameObject.SetActive(false);
		ach.gameObject.SetActive(false);
		about.gameObject.SetActive(false);
	}
	
	void achievementBackPressed()
	{
		home.gameObject.SetActive(true);
		stageSelect.gameObject.SetActive(false);
		sttng.gameObject.SetActive(false);
		ach.gameObject.SetActive(false);
		about.gameObject.SetActive(false);
	}
	
	void aboutBackPressed()
	{
		home.gameObject.SetActive(true);
		stageSelect.gameObject.SetActive(false);
		sttng.gameObject.SetActive(false);
		ach.gameObject.SetActive(false);
		about.gameObject.SetActive(false);
	}
	
	void tutorialPressed()
	{
		SceneManager.LoadScene("Tutorial");
	}
	
	void stage1Pressed()
	{
		SceneManager.LoadScene("Stage1");
	}
	
	void stage2Pressed()
	{
		SceneManager.LoadScene("Stage2");
	}
	
	void stage3Pressed()
	{
		SceneManager.LoadScene("Stage3");
	}
	
	void stage4Pressed()
	{
		SceneManager.LoadScene("Stage4");
	}
	
	void stage5Pressed()
	{
		SceneManager.LoadScene("Stage5");
	}
	
	void exitButtonPressed()
	{
		exitButtonPanel.gameObject.SetActive(true);
		logo.gameObject.SetActive(false);
		stageButton.gameObject.SetActive(false);
		settingButton.gameObject.SetActive(false);
		achievementButton.gameObject.SetActive(false);
		aboutButton.gameObject.SetActive(false);
		exitButton.gameObject.SetActive(false);
		txt.gameObject.SetActive(false);
	}
	
	void yesPressed()
	{
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}
	
	void noPressed()
	{
		exitButtonPanel.gameObject.SetActive(false);
		logo.gameObject.SetActive(true);
		stageButton.gameObject.SetActive(true);
		settingButton.gameObject.SetActive(true);
		achievementButton.gameObject.SetActive(true);
		aboutButton.gameObject.SetActive(true);
		exitButton.gameObject.SetActive(true);
		txt.gameObject.SetActive(true);
	}
}
