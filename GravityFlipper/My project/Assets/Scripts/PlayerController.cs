using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    public float wallClimbSpeed = 3f;
    public float gravity = 9.81f;

    private float currentSpeed;
    private bool isSprinting;
    private Vector2 gravityDirection = Vector2.down; // Initial gravity direction

    public float timer = 2;
    private float timer2 = 2;
    public bool canMove = true;

    private void Start()
    {
        timer2 = timer;
    }
    private void Update()
    {
        // Check for sprint input
        isSprinting = Input.GetKey(KeyCode.LeftShift);

        // Calculate current speed based on sprinting
        currentSpeed = isSprinting ? sprintSpeed : walkSpeed;

        // Apply gravity manually
        ApplyGravity();

        MovePlayer();

        ChangeGravityDirection();
    }
    private void ChangeGravityDirection()
    {
        if (canMove == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                gravityDirection = Vector2.up;
                canMove = false;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                gravityDirection = Vector2.down;
                canMove = false;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                gravityDirection = Vector2.left;
                canMove = false;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                gravityDirection = Vector2.right;
                canMove = false;
            }
        }
        else
        {
            timer2 -= Time.deltaTime;
            if(timer2 <= 0)
            {
                timer2 = timer;
                canMove = true;
            }
        }
    }

    private void ApplyGravity()
    {
        Physics2D.gravity = gravity * gravityDirection.normalized;
    }

    private void MovePlayer()
    {
        float horizontalInput = 0f;
        float verticalInput = 0f;

        // Check if the player is on the ground or on the wall
        if (gravityDirection == Vector2.down || gravityDirection == Vector2.up)
        {
            horizontalInput = Input.GetAxis("Horizontal");
        }
        else if (gravityDirection == Vector2.left || gravityDirection == Vector2.right)
        {
            verticalInput = Input.GetAxis("Vertical");
        }

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

        // Check if the player is on the left or right wall
        if ((gravityDirection == Vector2.left || gravityDirection == Vector2.right) &&
            (Mathf.Abs(Vector2.Dot(movement.normalized, gravityDirection)) > 0.9f))
        {
            // If on the wall, move up and down instead of left and right
            movement = new Vector3(0f, verticalInput, 0f) * (isSprinting ? sprintSpeed : wallClimbSpeed) * Time.deltaTime;
        }
        else
        {
            // Normal movement
            movement = movement * currentSpeed * Time.deltaTime;
        }

        transform.Translate(movement);
    }
}

