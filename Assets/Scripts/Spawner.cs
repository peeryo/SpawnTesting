using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Vector3 bottomLeftCorner;
    public Vector3 topRightCorner;
    public GameObject[] enemyPrefabs;
    public int numberOfEnemies;
    public Vector2 spawnTimeRange;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemies()
{
    for (int i = 0; i < numberOfEnemies; i++)
    {
        // Generate a random position within the square area
        float x = Random.Range(bottomLeftCorner.x, topRightCorner.x);
        float z = Random.Range(bottomLeftCorner.z, topRightCorner.z);
        Vector3 spawnPosition = new Vector3(x, bottomLeftCorner.y, z);

        //randomly choose an enemy prefab from an array
        GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        
        
        // Instantiate the enemy prefab at the generated position
        Instantiate(randomEnemyPrefab, spawnPosition, Quaternion.identity);

        // Wait for a random time between spawnTimeRange.x and spawnTimeRange.y before spawning the next enemy
        float waitTime = Random.Range(spawnTimeRange.x, spawnTimeRange.y);
        yield return new WaitForSeconds(waitTime);
    }
}
}
