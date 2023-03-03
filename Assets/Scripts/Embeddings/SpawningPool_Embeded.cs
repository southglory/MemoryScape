using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPool_Embeded : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public int numberOfPrefabsToSpawn = 5;
    public Vector3 spawnAreaCenter = Vector3.zero + Vector3.up * 2;
    public float spawnAreaRadius = 5f;

    void Start()
    {
        // Spawn the prefabs
        for (int i = 0; i < numberOfPrefabsToSpawn; i++)
        {
            // Calculate a random position within the spawn area
            Vector3 spawnPosition = spawnAreaCenter + Random.insideUnitSphere * spawnAreaRadius;

            // Instantiate the prefab at the spawn position with no rotation
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
    }

}
