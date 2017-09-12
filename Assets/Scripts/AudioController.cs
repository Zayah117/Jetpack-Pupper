using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    public static AudioController instance;
    public AudioFX audioFX;
    public Transform player;

    public bool soundOn;

	void Start () {
		if (instance == null) {
            instance = this;
        }
	}

    public void Blaster(Vector3 pos) {
        if (soundOn) {
            AudioSource.PlayClipAtPoint(audioFX.blasterSound, pos);
        }
    }

    public void Explosion(Vector3 pos, float volume) {
        if (soundOn) {
            AudioSource.PlayClipAtPoint(audioFX.explosion, pos, volume * 0.5f);
        }
    }
}
