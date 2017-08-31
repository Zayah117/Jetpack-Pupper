using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PupperController : MonoBehaviour {
    public VirtualJoystick virtualJoystick;
    public float rotationLimit;
    public float moveSpeed;
    public float bounds;
    public float fuel;
    public float fuelDrain; 

    float originalY;

    void Start() {
        originalY = transform.position.y;
    }

	void Update () {
        // Rotate
        gameObject.transform.eulerAngles = new Vector3(0, 0, virtualJoystick.input * rotationLimit * -1.0F);

        // Move
        transform.position += transform.up * Time.deltaTime * moveSpeed * GameController.instance.speedMultiplier;
        // Keep keep x in bounds and y at 0
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -bounds, bounds), originalY);

        // Drain fuel
        DrainFuel();
	}

    void DrainFuel() {
        fuel -= fuelDrain * Time.deltaTime * GameController.instance.speedMultiplier;
        if (fuel <= 0) {
            GameController.instance.KillPupper(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Asteroid")) {
            GameController.instance.KillPupper(gameObject);
        }
    }
}
