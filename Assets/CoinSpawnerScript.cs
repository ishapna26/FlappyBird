using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnerScript : MonoBehaviour
{
    public GameObject coinPrefab; // Reference to the coin prefab
    public float spawnRate = 2f; // Time interval between coin spawns
    public float xOffset = 10f; // Horizontal offset for coin spawn position
    public float yOffsetRange = 2f; // Vertical range for random spawn position

    private float timer = 0;

    void Start()
    {
        SpawnCoin();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnCoin();
            timer = 0;
        }
    }

    void SpawnCoin()
    {
        float yPos = Random.Range(-yOffsetRange, yOffsetRange); // Randomize vertical position
        Vector3 spawnPosition = new Vector3(transform.position.x + xOffset, yPos, 0);
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}
