using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController : MonoBehaviour {
    public float speed;
    public float speedBonus;
    public float fuel;
	
	void Update () {
        transform.position -= transform.up * Time.deltaTime * speed * GameController.instance.speedMultiplier;
	}

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            GameController.instance.speedMultiplier += speedBonus;

            collision.gameObject.GetComponent<PupperController>().fuel = Mathf.Clamp(collision.gameObject.GetComponent<PupperController>().fuel + fuel, 0.0f, 1.0f);

            Destroy(gameObject);
        }
    }
}
