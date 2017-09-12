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
            nextIndex += 1;
            if (nextIndex >= clips.Length) {
                nextIndex = 0;
            }
        }
	}
}
