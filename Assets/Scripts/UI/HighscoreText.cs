using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreText : MonoBehaviour {
	public Text text;

	void OnEnable() {
		text.text = "Highscore: " + SaveLoadManager.LoadScore().ToString();
	}
}
