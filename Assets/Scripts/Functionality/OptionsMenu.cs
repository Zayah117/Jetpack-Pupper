using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {
	public Slider soundSlider;
	public Slider musicSlider;

	void OnEnable() {
		soundSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1);
		musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
	}
}
