using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, ISpawnable, IPickup {
    public float speed;

    float _spawnAreaX = 2.5f;

    public float spawnAreaX {
        get { return _spawnAreaX; }
    }

    void Update() {
        Move();
    }

    public void ActivatePickup(GameObject player) {
        // Disable collider
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        // Heal player
        PupperController playerController = player.GetComponent<PupperController>();
        if (playerController.health < playerController.maxHealth) {
            playerController.Heal();
            Destroy(gameObject);
        }
    }

    public void Move() {
        transform.position -= transform.up * Time.deltaTime * speed * GameController.instance.speedMultiplier;
    }

    public void RotateTowards(Vector3 target) {
        transform.up = -(target - transform.position);
    }
}
