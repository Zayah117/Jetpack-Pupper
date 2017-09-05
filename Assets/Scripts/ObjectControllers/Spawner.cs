using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float spawnAreaX;
    public float targetAreaX;
    public float minSpawnRate;
    public float maxSpawnRate;
    public float spawnTriggerSpeed;
    public float fuelSpawnChance;
    public AsteroidController asteroid;
    public GameObject fuel;

    float fuelSpawnChanceIncrease = 0;
    float fuelAreaX = 2.5f;
    Vector3 target;
    AsteroidController currentAsteroid;

    public void SpawnObject() {
        SpawnAsteroid();

        if (Random.Range(0.0f, 1.0f) <= fuelSpawnChance + fuelSpawnChanceIncrease) {
            SpawnFuel();
        } else {
            fuelSpawnChanceIncrease += 0.01f;
        }
    }

    void SpawnAsteroid() {
        currentAsteroid = Instantiate(asteroid, new Vector3(Random.Range(-spawnAreaX / 2, spawnAreaX / 2), transform.position.y, 0), Quaternion.identity);
        target = new Vector3(Random.Range(-targetAreaX / 2, targetAreaX / 2), transform.GetChild(0).transform.position.y);
        currentAsteroid.RotateTowards(target);
    }

    void SpawnFuel() {
        Instantiate(fuel, new Vector3(Random.Range(-fuelAreaX, fuelAreaX), transform.position.y, 0), Quaternion.identity);
        fuelSpawnChanceIncrease = 0;
    }
}
