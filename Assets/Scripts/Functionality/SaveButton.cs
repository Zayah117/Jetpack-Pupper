using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveButton : MonoBehaviour {
	public AudioSource backgroundMusicSource;
	public Slider soundSlider;
	public Slider musicSlider;

	public void SaveVolume() {
		PlayerPrefs.SetFloat("SFXVolume", soundSlider.value);
		PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
		backgroundMusicSource.volume = PlayerPrefs.GetFloat("MusicVolume", 0.5f) * 0.5f;
	}
}
