using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeScript : MonoBehaviour {

    public AudioMixer mixer;
	Slider musicSlider, effectsSlider;
	Text musicText, effectsText;
	
	void Start ()
	{
		if (!SaveSystem.HasKey("MusicValue") || !SaveSystem.HasKey("EffectsValue"))
		{
			SaveSystem.SetFloat("MusicValue", 1);
			SaveSystem.SetFloat("EffectsValue", 1);
		}
		
		musicSlider = GameObject.Find("MusicSlider").GetComponent<Slider>();
		effectsSlider = GameObject.Find("EffectsSlider").GetComponent<Slider>();
		musicText = GameObject.Find("MusicText").GetComponent<Text>();
		effectsText = GameObject.Find("EffectsText").GetComponent<Text>();
		
		musicSlider.value = SaveSystem.GetFloat("MusicValue");
		effectsSlider.value = SaveSystem.GetFloat("EffectsValue");
		
		musicText.text = Mathf.Round(musicSlider.value * 100) + " %";
		effectsText.text = Mathf.Round(effectsSlider.value * 100) + " %";
	}

    public void MusicLevel (float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 60);
		SaveSystem.SetFloat("MusicValue", sliderValue);
		musicText.text = Mathf.Round(musicSlider.value * 100) + " %";
    }

    public void EffectsLevel (float sliderValue)
    {
        mixer.SetFloat("EffectsVol", Mathf.Log10(sliderValue) * 60);
		SaveSystem.SetFloat("EffectsValue", sliderValue);
		effectsText.text = Mathf.Round(effectsSlider.value * 100) + " %";
    }
}
