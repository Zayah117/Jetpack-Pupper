using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float minSpawnRate;
    public float maxSpawnRate;
    public float pickupChance;
    public GameObject asteroid;
    public GameObject[] pickups;

    float spawnRate;
    float nextSpawn;

    void Start() {
        spawnRate = NewSpawnRate();
    }

    void Update() {
        nextSpawn += Time.deltaTime * GameController.instance.speedMultiplier;
        if (nextSpawn > spawnRate) {
            spawnRate = NewSpawnRate();
            nextSpawn = 0;

            float chance = Random.Range(0.0f, 1.0f);
            if (chance <= pickupChance) {
                SpawnObject(pickups[Random.Range(0, pickups.Length)]);
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

    float NewSpawnRate() {
        return Random.Range(minSpawnRate, maxSpawnRate);
    }
}
