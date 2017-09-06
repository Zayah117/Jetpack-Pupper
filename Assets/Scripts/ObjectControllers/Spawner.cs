using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float minSpawnRate;
    public float maxSpawnRate;
    public float pickupChance;
    public int minPickupRate;
    public int maxPickupRate;
    public int minFuelRate;
    public int maxFuelRate;
    public GameObject asteroid;
    public GameObject fuel;
    public GameObject[] pickups;

    float spawnRate;
    float nextSpawn;
    int fuelRate;
    int nextFuel;
    int pickupRate;
    int nextPickup;

    void Start() {
        spawnRate = NewRate(minSpawnRate, maxSpawnRate);
        fuelRate = NewRate(minFuelRate, maxFuelRate);
        pickupRate = NewRate(minPickupRate, maxPickupRate);
    }

    void Update() {
        nextSpawn += Time.deltaTime * GameController.instance.speedMultiplier;
        if (nextSpawn > spawnRate) {
            spawnRate = NewRate(minSpawnRate, maxSpawnRate);
            nextSpawn = 0;
            nextFuel += 1;
            nextPickup += 1;

            // Pickup
            if (nextPickup >= pickupRate) {
                nextPickup = 0;
                pickupRate = NewRate(minPickupRate, maxPickupRate);
                SpawnObject(pickups[Random.Range(0, pickups.Length)]);
            // Fuel
            } else if (nextFuel >= fuelRate) {
                nextFuel = 0;
                fuelRate = NewRate(minFuelRate, maxFuelRate);
                SpawnObject(fuel);
            // Asteroid
            } else {
                SpawnObject(asteroid);
            }
        }
    }

    void SpawnObject(GameObject selectedObject) {
        // Spawn
        float spawnArea = selectedObject.GetComponent<ISpawnable>().spawnAreaX;
        GameObject currentObject = Instantiate(selectedObject, new Vector3(Random.Range(-spawnArea, spawnArea), transform.position.y, 0), Quaternion.identity);
        // Rotate
        currentObject.GetComponent<ISpawnable>().RotateTowards(new Vector3(Random.Range(-spawnArea, spawnArea), transform.GetChild(0).transform.position.y));
    }

    int NewRate(int min, int max) {
        return Random.Range(min, max);
    }

    float NewRate(float min, float max) {
        return Random.Range(min, max);
    }
}
