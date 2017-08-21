using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float spawnAreaX;
    public float targetAreaX;
    public AsteroidController asteroid;
    public float minSpawnRate;
    public float maxSpawnRate;

    bool canSpawn = false;
    float spawnRate;
    float nextSpawn = 0f;
    float speedMultiplier = 1.0f;
    Vector3 target;
    AsteroidController currentAsteroid;

    void Awake() {
        setNextSpawnTime();
        Invoke("ActivateSpawns", 3);
    }

    void Update() {
        nextSpawn += Time.deltaTime;
        if (canSpawn && nextSpawn > spawnRate) {
            nextSpawn -= spawnRate;
            SpawnObject();
            setNextSpawnTime();
        }
    }

    void SpawnObject() {
        currentAsteroid = Instantiate(asteroid, new Vector3(Random.Range(-spawnAreaX / 2, spawnAreaX / 2), transform.position.y, 0), Quaternion.identity);
        target = new Vector3(Random.Range(-targetAreaX / 2, targetAreaX / 2), transform.GetChild(0).transform.position.y);
        currentAsteroid.RotateTowards(target);
        currentAsteroid.MultiplySpeed(speedMultiplier);
    }

    void ActivateSpawns() {
        canSpawn = true;
    }

    void setNextSpawnTime() {
        spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
    }

    public void UpdateMultiplier(float multiplier) {
        speedMultiplier = multiplier;
    }
}
