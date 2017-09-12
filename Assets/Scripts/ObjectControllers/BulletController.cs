using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    public float speed;

    void Update () {
        transform.position += transform.up * Time.deltaTime * speed;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Asteroid")) {
            AsteroidController asteroidController = collision.GetComponent<AsteroidController>();
            asteroidController.Expload();
            AudioController.instance.Explosion(asteroidController.transform.position, asteroidController.scale);
            Destroy(gameObject);
        }
    }
}
