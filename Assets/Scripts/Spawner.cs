using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float spawnAreaX;
    public float targetAreaX;
    public float minSpawnRate;
    public float maxSpawnRate;
    public float spawnTriggerSpeed;
    public AsteroidController asteroid;

    Vector3 target;
    AsteroidController currentAsteroid;

    public void SpawnObject() {
        currentAsteroid = Instantiate(asteroid, new Vector3(Random.Range(-spawnAreaX / 2, spawnAreaX / 2), transform.position.y, 0), Quaternion.identity);
        target = new Vector3(Random.Range(-targetAreaX / 2, targetAreaX / 2), transform.GetChild(0).transform.position.y);
        currentAsteroid.RotateTowards(target);
    }
}
