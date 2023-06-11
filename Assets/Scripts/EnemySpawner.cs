using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform spawnPoint;
    public float spawnInterval = 2f;

    private float spawnTimer = 0f;

    private void Update()
    {
        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }

        spawnTimer += Time.deltaTime;
    }

    private void SpawnEnemy()
    {

        int randomIndex = Random.Range(0, enemyPrefabs.Length);


        GameObject enemyPrefab = enemyPrefabs[randomIndex];
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}