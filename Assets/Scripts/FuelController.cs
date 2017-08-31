using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController : MonoBehaviour {
    public float speed;
    public float speedBonus;
	
	void Update () {
        transform.position -= transform.up * Time.deltaTime * speed * GameController.instance.speedMultiplier;
	}

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            GameController.instance.speedMultiplier += speedBonus;
            Destroy(gameObject);
        }
    }
}
