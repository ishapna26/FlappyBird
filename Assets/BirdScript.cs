using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public int lives = 3;  // Add a variable to track the number of lives

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        lives--;  // Decrease the number of lives
        logic.updateLives(lives);  // Update the UI
        if (lives <= 0)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
        else
        {
            // Reset the bird position or implement a small pause before continuing
            myRigidbody.velocity = Vector2.zero;
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
}
