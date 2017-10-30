using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveButton : MonoBehaviour {
	public Slider soundSlider;
	public Slider musicSlider;

	public void SaveVolume() {
		PlayerPrefs.SetFloat("SFXVolume", soundSlider.value);
		PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
	}
}
