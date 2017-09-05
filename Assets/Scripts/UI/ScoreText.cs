using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {
    Text myText;

    int score;

    void Start() {
        myText = GetComponent<Text>();
    }

    void Update() {
        GetScore();
        myText.text = "Score: " + score.ToString();
    }

    void GetScore() {
        score = GameController.instance.playerScore;
    }
}
