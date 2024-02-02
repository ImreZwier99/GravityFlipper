using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Enemy : MonoBehaviour
{
    //deze enemy loopt heen en weer.


    public float MoveDistancePositive = 5f; // Adjust the distance to the right as needed
    public float MoveDistanceNegative = -5f; // Adjust the distance to the left as needed
    public float moveSpeed = 5f; // Adjust the speed as needed
    private bool facingRight = true;

    void Update()
    {
        // Move the enemy horizontally
        Move();

        // Check if the enemy needs to flip its direction
        CheckFlip();
    }

    void Move()
    {
        float horizontalMovement = moveSpeed * Time.deltaTime;
        if (facingRight)
        {
            transform.Translate(Vector2.right * horizontalMovement);
        }
        else
        {
            transform.Translate(Vector2.left * horizontalMovement);
        }
    }

    void CheckFlip()
    {
        // Check if the enemy needs to flip its direction
        if ((facingRight && transform.position.x >= MoveDistancePositive) || (!facingRight && transform.position.x <= MoveDistanceNegative))
        {
            Flip();
        }
    }

    void Flip()
    {
        // Flip the enemy's direction
        facingRight = !facingRight;

        // Flip the sprite
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}