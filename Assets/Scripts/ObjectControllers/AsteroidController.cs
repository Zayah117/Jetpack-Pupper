using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour, ISpawnable {

    public float minSpeed;
    public float maxSpeed;
    public float minScale;
    public float maxScale;
    public Vector3 target;

    float moveSpeed;
    float scale;
    float _spawnAreaX = 3.0f;

    public float spawnAreaX {
        get { return _spawnAreaX; }
    }

    void Awake() {
        moveSpeed = Random.Range(minSpeed, maxSpeed);
        scale = Random.Range(minScale, maxScale);
        gameObject.transform.localScale = new Vector3(scale, scale);
    }

    void Update() {
        Move();
    }

    public void Move() {
        transform.position += transform.up * Time.deltaTime * moveSpeed * GameController.instance.speedMultiplier;
    }

    public void RotateTowards(Vector3 target) {
        transform.up = target - transform.position;
    }
}
