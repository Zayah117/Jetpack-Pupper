using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {
    public float moveSpeed;

	void Update () {
        transform.position += transform.up * Time.deltaTime * moveSpeed * -1.0f;
	}
}
