using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;

public class Lane1Spawner : MonoBehaviour
{

    [SerializeField] GameObject[] vehicalsPrefabs;
    [SerializeField] float spawnDelay = 2f; // Delay between each spawn

    void Start()
    {
        // Start spawning vehicles immediately upon scene start
        StartCoroutine(SpawnSequentially());
    }

    IEnumerator SpawnSequentially()
    {
        while (true)
        {
            // Select a random vehicle prefab from the array
            GameObject randomPrefab = vehicalsPrefabs[Random.Range(0, vehicalsPrefabs.Length)];

            // Instantiate the selected vehicle prefab at the spawner's position and rotation
            Instantiate(randomPrefab, transform.position, transform.rotation);

            // Wait for the specified spawn delay before spawning the next vehicle
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
