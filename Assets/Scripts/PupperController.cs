using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PupperController : MonoBehaviour {
    public VirtualJoystick virtualJoystick;
    public GameObject bullet;
    public Transform rightCannon;
    public Transform leftCannon;
    public float rotationLimit;
    public float moveSpeed;
    public float bounds;
    public float fuel;
    public float fuelDrain;
    public float fireRate;
    public int maxHealth = 4;
    public int health;

    float originalY;
    float fireTime;
    bool fireEnabled;

    void Start() {
        originalY = transform.position.y;
        health = 4;
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

        // Fire Cannons
        ToggleFireEnabled(virtualJoystick.fireEnabled); // Checks if joystick.fireEnabled has changed
        fireTime += Time.deltaTime;
        if (fireEnabled && fireTime > fireRate) {
            FireCannons();
        }
	}

    void DrainFuel() {
        fuel -= fuelDrain * Time.deltaTime * GameController.instance.speedMultiplier;
        if (fuel <= 0) {
            GameController.instance.KillPupper(gameObject);
        }
    }

    void FireCannons() {
        Instantiate(bullet, rightCannon.position, gameObject.transform.rotation);
        Instantiate(bullet, leftCannon.position, gameObject.transform.rotation);
        fireTime -= fireRate;
    }

    void ToggleFireEnabled(bool joystickInput) {
        if (!fireEnabled && joystickInput == true) {
            fireTime = fireRate;
            fireEnabled = true;
        } else if (fireEnabled && joystickInput == false) {
            fireEnabled = false;
        }
    }

    void TakeDamage() {
        health -= 1;
        GameController.instance.UpdateHealthBars(gameObject);
        if (health <= 0) {
            GameController.instance.KillPupper(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Asteroid")) {
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }
}
