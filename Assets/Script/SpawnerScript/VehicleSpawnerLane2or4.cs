using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawnerLane2or4 : MonoBehaviour
{

    [SerializeField] GameObject[] vehicalsPrefabs;
    [SerializeField] float spawnDelay; // Delay between each spawn
    int spawnNum;
    bool spawnAgain = false;
    bool changeTimer;
    float spawnAgainTime;

    void Start()
    {
        DelayInSpawning();
        // Start spawning vehicles immediately upon scene start
        SpawningVehicalsValue();
        //timer between spawning new vehcicals;



    }

    private void Update()
    {

        if (changeTimer)
        {
            spawnAgainTime -= Time.deltaTime;
            // Debug.Log("spawnAgaintimer : " + spawnAgainTime);
            if (spawnAgainTime <= 0)
            {

                DelayInSpawning();
                if (spawnAgain)
                {
                    Debug.Log("SpawnAgain");
                    SpawningVehicalsValue();

                    changeTimer = false;
                    spawnAgain = false;
                }

            }
        }



    }
    void ResetTimer()
    {
        spawnAgainTime = Random.Range(15, 30);
        //  Debug.Log("spawnAgaintimer : " + spawnAgainTime);
        changeTimer = true;
        //  spawnAgain = false;
    }
    void SpawningVehicalsValue()
    {
        int spawnnum = Random.Range(0, 5);

        StartCoroutine(SpawnSequentially(spawnnum));
    }
    void DelayInSpawning()
    {

        spawnDelay = Random.Range(8, 15);

        spawnAgain = true;
    }

    IEnumerator SpawnSequentially(int spawnnum)
    {
        spawnAgain = false;
        for (int i = 0; i <= spawnnum; i++)
        {
            // Select a random vehicle prefab from the array
            GameObject randomPrefab = vehicalsPrefabs[Random.Range(0, vehicalsPrefabs.Length)];

            // Instantiate the selected vehicle prefab at the spawner's position and rotation
            Instantiate(randomPrefab, transform.position, transform.rotation);

            // Wait for the specified spawn delay before spawning the next vehicle
            yield return new WaitForSeconds(spawnDelay);

        }
        Debug.Log("Outer looop");
        ResetTimer();


    }

}
