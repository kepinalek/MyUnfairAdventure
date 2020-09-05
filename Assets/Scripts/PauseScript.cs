using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
	Button pauseBtn, resumeBtn, settingBtn, settingBackBtn, menuBtn;
	GameObject pausePnl, settingPnl;
	
    void Awake()
    {
		Time.timeScale = 1;
		
		pauseBtn = GameObject.Find("PauseButton").GetComponent<Button>();
		resumeBtn = GameObject.Find("ResumeButton").GetComponent<Button>();
		settingBtn = GameObject.Find("SettingButton").GetComponent<Button>();
		settingBackBtn = GameObject.Find("SettingBackBtn").GetComponent<Button>();
		menuBtn = GameObject.Find("MenuButton").GetComponent<Button>();
		pausePnl = GameObject.Find("PausePanel");
		settingPnl = GameObject.Find("SettingPanel");
		
		pausePnl.SetActive(false);
		settingPnl.SetActive(false);
		
		pauseBtn.onClick.AddListener(pauseBtnPressed);
		resumeBtn.onClick.AddListener(resumeBtnPressed);
		settingBtn.onClick.AddListener(settingBtnPressed);
		settingBackBtn.onClick.AddListener(settingBackBtnPressed);
		menuBtn.onClick.AddListener(menuBtnPressed);
    }
	
	void pauseBtnPressed()
	{
		Time.timeScale = 0;
		pausePnl.SetActive(true);
		pauseBtn.gameObject.SetActive(false);
	}
	
	void resumeBtnPressed()
	{
		Time.timeScale = 1;
		pausePnl.SetActive(false);
		pauseBtn.gameObject.SetActive(true);
	}
	
	void settingBtnPressed()
	{
		pausePnl.SetActive(false);
		settingPnl.SetActive(true);
	}
	
	void settingBackBtnPressed()
	{
		pausePnl.SetActive(true);
		settingPnl.SetActive(false);
	}
	
	void menuBtnPressed()
	{
		SceneManager.LoadScene("MainMenu");
		Destroy(GameObject.Find("BGM"));
		Destroy(GameObject.Find("Script"));
	}
}
