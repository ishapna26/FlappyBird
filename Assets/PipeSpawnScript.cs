using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2; // Increase this value to spawn pipes less frequently
    private float timer = 0;
    public float heightOffset = 0;
    public float xOffset = 2; // New variable to control x offset

    void Start()
    {
        spawnPipe();
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        float xPos = transform.position.x + xOffset; // Adjust the x position
        Instantiate(pipe, new Vector3(xPos, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
