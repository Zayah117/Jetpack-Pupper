using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static GameController instance;
    public float restartDelay;
    public float speedMultiplier = 1.0f;
    public Spawner spawner;

    float speedMultiRate = 1.0f;
    float nextSpeedMultiplyer = 0f;

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
            spawner.UpdateMultiplier(speedMultiplier);
        }
    }

    void UpSpeed() {
        speedMultiplier += 0.01f;
    } 

    public void KillPupper(GameObject player) {
        player.SetActive(false);
        Invoke("RestartGame", restartDelay);
    }

    void RestartGame() {
        SceneManager.LoadScene("scene");
    }
}
