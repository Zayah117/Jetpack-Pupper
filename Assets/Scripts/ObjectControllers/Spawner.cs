using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float minSpawnRate;
    public float maxSpawnRate;
    public GameObject asteroid;
    public GameObject[] powerups;

    float spawnRate;
    float nextSpawn;
    //float spawnAreaX = 3.5f;
    //float targetAreaX = 3.5f;
    //float powerupAreaX = 2.5f;
    //Vector3 target;
    //GameObject currentAsteroid;

    void Start() {
        spawnRate = NewSpawnRate();
    }

    void Update() {
        nextSpawn += Time.deltaTime * GameController.instance.speedMultiplier;
        if (nextSpawn > spawnRate) {
            spawnRate = NewSpawnRate();
            nextSpawn = 0;
            SpawnObject(asteroid);
        }
    }

    void SpawnObject(GameObject selectedObject) {
        // Spawn
        GameObject currentObject = Instantiate(selectedObject, new Vector3(Random.Range(-3.0f, 3.0f), transform.position.y, 0), Quaternion.identity);
        // Rotate
        currentObject.GetComponent<ISpawnable>().RotateTowards(new Vector3(Random.Range(-3.0f, 3.0f), transform.GetChild(0).transform.position.y));
    }

    float NewSpawnRate() {
        return Random.Range(minSpawnRate, maxSpawnRate);
    }

    /*
    void SpawnAsteroid() {
        currentAsteroid = Instantiate(asteroid, new Vector3(Random.Range(-spawnAreaX / 2, spawnAreaX / 2), transform.position.y, 0), Quaternion.identity);
        target = new Vector3(Random.Range(-targetAreaX / 2, targetAreaX / 2), transform.GetChild(0).transform.position.y);
        currentAsteroid.GetComponent<ISpawnable>().RotateTowards(target);
    }

    void SpawnFuel() {
        Instantiate(fuel, new Vector3(Random.Range(-fuelAreaX, fuelAreaX), transform.position.y, 0), Quaternion.identity);
        fuelSpawnChanceIncrease = 0;
    }
    */
}
