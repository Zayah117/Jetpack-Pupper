using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static GameController instance;
    public GameObject gameOverPanel;
    public float restartDelay;
    public float speedMultiplier = 0.5f;
    public float speedMultiRate = 1.0f;
    public int playerScore = 0;
    public bool pupperIsDead;

    float nextSpeedMultiplyer;
    float nextScoreIncrease;
    float scoreIncreaseRate = 1;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Update() {
        if (!pupperIsDead) {
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
    }

    void UpSpeed() {
        speedMultiplier += 0.01f;
    }

    void UpScore() {
        playerScore += 1;
    }

    public void KillPupper(GameObject player) {
        pupperIsDead = true;
        player.SetActive(false);

        gameOverPanel.SetActive(true);

        // Invoke("RestartGame", restartDelay);
    }

    void RestartGame() {
        SceneManager.LoadScene("Scene");
    }
}
