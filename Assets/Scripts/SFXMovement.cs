using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXMovement : MonoBehaviour {
    public float speed;
	
	void Update () {
        Move();
	}

    void Move() {
        transform.position -= transform.up * Time.deltaTime * speed * GameController.instance.speedMultiplier;
    }
}
