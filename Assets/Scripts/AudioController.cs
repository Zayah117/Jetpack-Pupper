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

	void Update () {
		
	}
}