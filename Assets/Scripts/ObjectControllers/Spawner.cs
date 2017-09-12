using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float minSpawnRate;
    public float maxSpawnRate;
    public float pickupChance;
    public int minPickupRate;
    public int maxPickupRate;
    public int minScorePickupRate;
    public int maxScorePickupRate;
    public GameObject asteroid;
    public GameObject scorePickup;
    public GameObject[] pickups;

    float spawnRate;
    float nextSpawn;
    int scorePickupRate;
    int nextScorePickup;
    int pickupRate;
    int nextPickup;

    void Start() {
        spawnRate = NewRate(minSpawnRate, maxSpawnRate);
        scorePickupRate = NewRate(minScorePickupRate, maxScorePickupRate);
        pickupRate = NewRate(minPickupRate, maxPickupRate);
    }

    void Update() {
        nextSpawn += Time.deltaTime * GameController.instance.speedMultiplier;
        if (nextSpawn > spawnRate) {
            spawnRate = NewRate(minSpawnRate, maxSpawnRate);
            nextSpawn = 0;
            nextScorePickup += 1;
            nextPickup += 1;

            // Pickup
            if (nextPickup >= pickupRate) {
                nextPickup = 0;
                pickupRate = NewRate(minPickupRate, maxPickupRate);
                SpawnObject(pickups[Random.Range(0, pickups.Length)]);
            // Score Pickup
            } else if (nextScorePickup >= scorePickupRate) {
                nextScorePickup = 0;
                scorePickupRate = NewRate(minScorePickupRate, maxScorePickupRate);
                SpawnObject(scorePickup);
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
