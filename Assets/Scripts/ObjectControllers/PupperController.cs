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
    float fireCoolDown;
    bool isFiring;

    void Start() {
        originalY = transform.position.y;
        health = 4;
    }

	void Update () {
        // Rotate
        gameObject.transform.eulerAngles = new Vector3(0, 0, virtualJoystick.input.x * rotationLimit * -1.0F);

        // Move
        transform.position += transform.up * Time.deltaTime * moveSpeed * GameController.instance.speedMultiplier;
        // Keep keep x in bounds and y at 0
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -bounds, bounds), originalY);

        // Drain fuel
        //DrainFuel();

        // Fire Cannons
        fireCoolDown += Time.deltaTime * GameController.instance.speedMultiplier;
        if (virtualJoystick.input.y > virtualJoystick.yThreshold && fireCoolDown > fireRate) {
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
        fireCoolDown = 0;
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
        } else if (collision.gameObject.CompareTag("Pickup")) {
            collision.gameObject.GetComponent<IPickup>().ActivatePickup(gameObject);
        }
    }
}
