using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

    public float minSpeed;
    public float maxSpeed;
    public float minScale;
    public float maxScale;
    public Vector3 target;

    float speedMultiplier;
    float moveSpeed;
    float scale;

    void Awake() {
        moveSpeed = Random.Range(minSpeed, maxSpeed);
        scale = Random.Range(minScale, maxScale);
        gameObject.transform.localScale = new Vector3(scale, scale);
    }

    public void RotateTowards(Vector3 target) {
        transform.up = target - transform.position;
    }

    public void MultiplySpeed(float multiplier) {
        speedMultiplier = multiplier;
    }

    void Update () {
        transform.position += transform.up * Time.deltaTime * moveSpeed * speedMultiplier;
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Asteroid") {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
    }
}
