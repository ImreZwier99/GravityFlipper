using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the enemy movement
    public float moveRight = 1f;
    public float moveLeft = -1f;
    private bool movingRight = true; // Flag to determine the direction of movement

    // Update is called once per frame
    void Update()
    {
        // Move the enemy based on the direction
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        // Check if the enemy is reaching the screen edges to change direction
        if (transform.position.x >= moveRight) // Assuming the screen width is 18 units
        {
            movingRight = false;
        }
        else if (transform.position.x <= moveLeft) // Assuming the screen width is 18 units
        {
            movingRight = true;
        }
    }
}
