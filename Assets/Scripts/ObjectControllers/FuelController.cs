using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController : MonoBehaviour, ISpawnable, IPickup {
    public float speed;
    public float speedBonus;
    public float fuel;
    public int scoreValue;

    float _spawnAreaX = 2.5f;

    public float spawnAreaX {
        get { return _spawnAreaX; }
    }
	
	void Update () {
        Move();
	}

    public void ActivatePickup(GameObject player) {
        GameController.instance.speedMultiplier += speedBonus;
        GameController.instance.playerScore += scoreValue;

        player.GetComponent<PupperController>().fuel = Mathf.Clamp(player.GetComponent<PupperController>().fuel + fuel, 0.0f, 1.0f);

        Destroy(gameObject);
    }

    public void Move() {
        transform.position -= transform.up * Time.deltaTime * speed * GameController.instance.speedMultiplier;
    }

    public void RotateTowards(Vector3 target) {
        transform.up = -(target - transform.position);
    }
}
