using UnityEngine;

public class GravityChanger : MonoBehaviour
{
    public float gravityScale = 1f; // Adjust this to control the strength of gravity

    void Update()
    {
        // Get input from arrow keys directly
        float horizontalInput = Input.GetKey(KeyCode.RightArrow) ? 1 : (Input.GetKey(KeyCode.LeftArrow) ? -1 : 0);
        float verticalInput = Input.GetKey(KeyCode.UpArrow) ? 1 : (Input.GetKey(KeyCode.DownArrow) ? -1 : 0);

        // Calculate the gravity direction based on input
        Vector2 gravityDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // Change gravity direction
        if (gravityDirection != Vector2.zero)
        {
            SetGravityDirection(gravityDirection);
        }
    }

    void SetGravityDirection(Vector2 direction)
    {
        // Calculate the angle based on the input direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Set the rotation of the Rigidbody2D to match the calculated angle
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Set the gravity direction
        Physics2D.gravity = direction * gravityScale;
    }
}


