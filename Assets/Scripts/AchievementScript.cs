using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementScript : MonoBehaviour
{
	Text[] a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11;
	
    void Start()
    {
        a1  = gameObject.transform.GetChild (0).GetComponentsInChildren<Text>();
        a2  = gameObject.transform.GetChild (1).GetComponentsInChildren<Text>();
        a3  = gameObject.transform.GetChild (2).GetComponentsInChildren<Text>();
        a4  = gameObject.transform.GetChild (3).GetComponentsInChildren<Text>();
        a5  = gameObject.transform.GetChild (4).GetComponentsInChildren<Text>();
        a6  = gameObject.transform.GetChild (5).GetComponentsInChildren<Text>();
        a7  = gameObject.transform.GetChild (6).GetComponentsInChildren<Text>();
        a8  = gameObject.transform.GetChild (7).GetComponentsInChildren<Text>();
        a9  = gameObject.transform.GetChild (8).GetComponentsInChildren<Text>();
        a10 = gameObject.transform.GetChild (9).GetComponentsInChildren<Text>();
        a11 = gameObject.transform.GetChild(10).GetComponentsInChildren<Text>();
		
		a1 [0].text = "Hidden Achievement";
		a2 [0].text = "Hidden Achievement";
		a3 [0].text = "Hidden Achievement";
		a4 [0].text = "Hidden Achievement";
		a5 [0].text = "Hidden Achievement";
		a6 [0].text = "Hidden Achievement";
		a7 [0].text = "Hidden Achievement";
		a8 [0].text = "Hidden Achievement";
		a9 [0].text = "Hidden Achievement";
		a10[0].text = "Hidden Achievement";
		a11[1].text = "*Hidden Requirement";
		
		if (SaveSystem.GetInt("Level") >= 1)
		{
			a1[0].text = "This Is Just The Beginning.";
			a1[2].text = "Unlocked";
		}
		
		if (SaveSystem.GetInt("Level") >= 2)
		{
			a2[0].text = "Mastery Up For The First Time. Feels good, isn't it ?";
			a2[2].text = "Unlocked";
		}
		
		if (SaveSystem.GetInt("Level") >= 5)
		{
			a3[0].text = "Keep Dying And Something Good Maybe Happen.";
			a3[2].text = "Unlocked";
		}
		
		if (SaveSystem.GetInt("Level") >= 10)
		{
			a4[0].text = "What Are You ? A Masochist ?";
			a4[2].text = "Unlocked";
		}
		
		if (SaveSystem.GetInt("Level") >= 15)
		{
			a5[0].text = "Nope, Nothing Good Will Happen, Only You That Keep Dying.";
			a5[2].text = "Unlocked";
		}
		
		if (SaveSystem.GetBool("Stage1Cleared"))
		{
			a6[0].text = "Stage 1, not that hard, is it ?";
			a6[2].text = "Unlocked";
		}
		
		if (SaveSystem.GetBool("Stage2Cleared"))
		{
			a7[0].text = "That Trap At The Beginning Really Got You Good, eh ?";
			a7[2].text = "Unlocked";
		}
		
		if (SaveSystem.GetBool("Stage3Cleared"))
		{
			a8[0].text = "Haha Jumping Slime Goes Brrrr.";
			a8[2].text = "Unlocked";
		}
		
		if (SaveSystem.GetBool("Stage4Cleared"))
		{
			a9[0].text = "Lava Lava Lava.";
			a9[2].text = "Unlocked";
		}
		
		if (SaveSystem.GetBool("Stage5Cleared"))
		{
			a10[0].text = "That Trap At The Checkpoint Really Got You Good, eh ?";
			a10[2].text = "Unlocked";
		}
		
		if (SaveSystem.GetBool("finish") && TimerScript.timer >= 0f || SaveSystem.GetBool("LastAchievement"))
		{
			a11[1].text = "*Finish all the stages under 1 minute";
			a11[2].text = "Unlocked";
			SaveSystem.SetBool("LastAchievement", true);
		}
    }
}
