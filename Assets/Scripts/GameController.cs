using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static GameController instance;
    public float restartDelay;
    public float speedMultiplier = 0.5f;
    public float speedMultiRate = 1.0f;
    public int playerScore = 0;
    public bool pupperIsDead;
    public UI ui;

    float nextSpeedMultiplyer;
    float nextScoreIncrease;
    float scoreIncreaseRate = 1;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Start() {
        Screen.orientation = ScreenOrientation.Portrait;
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

    public void UpdateHealthBars(GameObject player) {
        int playerHealth = player.GetComponent<PupperController>().health;

        if (playerHealth == 4) {
            ui.health1.color = ui.red;
            ui.health2.color = ui.red;
            ui.health3.color = ui.red;
            ui.health4.color = ui.red;
        } else if (playerHealth == 3) {
            ui.health1.color = ui.white;
            ui.health2.color = ui.red;
            ui.health3.color = ui.red;
            ui.health4.color = ui.red;
        } else if (playerHealth == 2) {
            ui.health1.color = ui.white;
            ui.health2.color = ui.white;
            ui.health3.color = ui.red;
            ui.health4.color = ui.red;
        } else if (playerHealth == 1) {
            ui.health1.color = ui.white;
            ui.health2.color = ui.white;
            ui.health3.color = ui.white;
            ui.health4.color = ui.red;
        } else {
            ui.health1.color = ui.white;
            ui.health2.color = ui.white;
            ui.health3.color = ui.white;
            ui.health4.color = ui.white;
        }
    }

    public void KillPupper(GameObject player) {
        pupperIsDead = true;
        player.SetActive(false);

        ui.hudPanel.SetActive(false);
        ui.gameOverPanel.SetActive(true);

        // Invoke("RestartGame", restartDelay);
    }

    void RestartGame() {
        SceneManager.LoadScene("Scene");
    }
}
