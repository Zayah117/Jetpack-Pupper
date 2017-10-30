using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {
    public AudioClip[] clips;

    AudioSource audioSource;
    int nextIndex;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }
	
	void Update () {
		if (!audioSource.isPlaying) {
            audioSource.clip = clips[nextIndex];
			audioSource.Play();
			audioSource.volume = PlayerPrefs.GetFloat("MusicVolume", 0.5f) * 0.5f;
            nextIndex += 1;
            if (nextIndex >= clips.Length) {
                nextIndex = 0;
            }
        }
	}
}
