using UnityEngine;

public class GravityChanger : MonoBehaviour
{
    public float gravity = 9.81f;
    public float timer = 2;
    private float timer2 = 2;
    public bool canMove = true;

    private Vector2 gravityDirection = Vector2.down; // Initial gravity direction

    private void Start()
    {
        timer2 = timer;
    }
    private void ChangeGravityDirection()
    {
        if(canMove == true)
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
            if (timer2 <= 0)
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

    public void Update()
    {
        // Change gravity direction based on arrow keys
        ChangeGravityDirection();

        // Apply gravity manually
        ApplyGravity();
    }
}


