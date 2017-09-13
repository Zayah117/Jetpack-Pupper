using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour, ISpawnable, IPickup {

    public float speed;
    public int ammoValue;

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

        // Give ammo
        PupperController playerController = player.GetComponent<PupperController>();
        if (playerController.ammo < playerController.maxAmmo) {
            AudioController.instance.Bullets(transform.position);
            playerController.ammo = Mathf.Clamp(playerController.ammo + ammoValue, 0, playerController.maxAmmo);
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
