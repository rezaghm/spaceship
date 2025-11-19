using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;

    // Time interval between spawns.
    public float spawnInterval = 4.0f;

    // Timer to track when the next spawn should happen.
    private float nextSpawnTime;

    public int minSpawnInterval = -4;
    public int maxSpawnInterval = 4;

    private int randomPosition;

    void Start()
    {
        nextSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            // Call the function to create the object.
            SpawnEnemy();

            // Set the time for the next spawn.
            nextSpawnTime = Time.time + spawnInterval;

             randomPosition = Random.Range(minSpawnInterval, maxSpawnInterval);

        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x + randomPosition,transform.position.y,transform.position.z);
        Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);

    }
}
