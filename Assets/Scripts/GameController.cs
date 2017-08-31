using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static GameController instance;
    public float restartDelay;
    public float speedMultiplier = 0.5f;
    public float speedMultiRate = 1.0f;
    public int playerScore = 0;

    float nextSpeedMultiplyer;
    float nextScoreIncrease;
    float scoreIncreaseRate = 1;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Update() {
        nextSpeedMultiplyer += Time.deltaTime;
        if (nextSpeedMultiplyer > speedMultiRate) {
            nextSpeedMultiplyer -= speedMultiRate;
            UpSpeed();
        }

        nextScoreIncrease += Time.deltaTime;
        if (nextScoreIncrease > scoreIncreaseRate) {
            nextScoreIncrease -= scoreIncreaseRate;
            UpScore();
        }
    }

    void UpSpeed() {
        speedMultiplier += 0.01f;
    }

    void UpScore() {
        playerScore += 1;
    }

    public void KillPupper(GameObject player) {
        player.SetActive(false);
        Invoke("RestartGame", restartDelay);
    }

    void RestartGame() {
        SceneManager.LoadScene("scene");
    }
}
