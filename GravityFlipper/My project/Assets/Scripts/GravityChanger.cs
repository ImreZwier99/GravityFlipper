using UnityEngine;

public class GravityChanger : MonoBehaviour
{
    public float gravity = 9.81f;
    private Vector2 gravityDirection = Vector2.down; // Initial gravity direction
    private void ChangeGravityDirection()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gravityDirection = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gravityDirection = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gravityDirection = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gravityDirection = Vector2.right;
        }
    }

    private void ApplyGravity()
    {
        Physics2D.gravity = gravity * gravityDirection.normalized;
    }

    public void Update()
    {
        // Change gravity direction based on arrow keys
        ChangeGravityDirection();

        // Apply gravity manually
        ApplyGravity();
    }
}


