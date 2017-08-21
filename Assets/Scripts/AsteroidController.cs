using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

    public float minSpeed;
    public float maxSpeed;
    public Vector3 target;
    float moveSpeed;

    void Awake() {
        moveSpeed = Random.Range(minSpeed, maxSpeed);
    }

    public void RotateTowards(Vector3 target) {
        transform.up = target - transform.position;
    }

    void Update () {
        transform.position += transform.up * Time.deltaTime * moveSpeed;
	}
}
