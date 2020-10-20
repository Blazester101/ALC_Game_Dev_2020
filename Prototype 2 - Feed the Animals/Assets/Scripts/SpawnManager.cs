using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Brings in animal prefabs
    public GameObject[] animalPrefabs;
    // Spawn position variables
    private float spawnRangeX = 20.0f;
    private float spawnPosZ = -5.0f;

    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;

    public float difficultyIncreaseDelay = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        // Adds automatic spawning
        InvokeRepeating("SpawnRandomAnimals", startDelay, spawnInterval);
        InvokeRepeating("DifficultyIncrease", difficultyIncreaseDelay, difficultyIncreaseDelay);
    }

    // Spawns animals randomly
    void SpawnRandomAnimals()
    {
        // Randomly generate animal index and spawn position
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        // Instantiates the animals
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    void DifficultyIncrease()
    {
        spawnIntervalCopy = spawnInterval * (50 / 100);
    }
}
