using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, ISpawnable, IPickup {
    public float speed;
	public float rotateSpeed;
	public SpriteRenderer sprite;

    float _spawnAreaX = 2.5f;

    public float spawnAreaX {
        get { return _spawnAreaX; }
    }

    void Update() {
        Move();
		RotateSprite();
    }

    public void ActivatePickup(GameObject player) {
        // Disable collider
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        // Heal player
        PupperController playerController = player.GetComponent<PupperController>();
        if (playerController.health < playerController.maxHealth) {
            AudioController.instance.Health(transform.position);
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

	void RotateSprite() {
		float rotation = rotateSpeed * Time.deltaTime;
		sprite.transform.Rotate(new Vector3(0, 0, rotation));
	}
}
