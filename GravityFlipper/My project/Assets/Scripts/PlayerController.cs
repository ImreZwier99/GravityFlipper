using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // De snelheid van het bewegen
    public float climbSpeed = 3f; // De snelheid van het beklimmen en afdalen
    public float jumpForce = 10f; // De kracht van de sprong

    public GameObject deathMenu; // UI element for the death screen
    public Transform teleportPoint; // The point to teleport the player to
    public TMP_Text healthText; // Reference to the TMP Text component

    public int lifes = 3; // Number of lives

    private bool isGravityFlipped = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        deathMenu.SetActive(false); // Ensure the death menu is initially hidden

        if (teleportPoint == null)
        {
            // Find the teleport point by tag if it's not set in the Inspector
            teleportPoint = GameObject.FindWithTag("TeleportPoint").transform;
            if (teleportPoint == null)
            {
                Debug.LogError("Teleport point not found! Please assign a teleport point in the Inspector or tag a GameObject as 'TeleportPoint'.");
            }
        }

        UpdateHealthText(); // Initialize the health text
    }

    void Update()
    {
        // Bewegen op de grond
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

        // Zwaartekracht omdraaien met spatiebalk
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FlipGravity();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            LoseLife();
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            LoseLife();
            Destroy(collision.gameObject); // Destroy the bullet
        }
    }

    private void LoseLife()
    {
        lifes--;
        Debug.Log("Lives remaining: " + lifes);
        UpdateHealthText(); // Update the health text when lives change

        // Reset gravity to normal if flipped
        if (isGravityFlipped)
        {
            FlipGravity();
        }

        if (lifes <= 0)
        {
            Debug.Log("Player has died. Showing death menu.");
            deathMenu.SetActive(true);
            Time.timeScale = 0; // Pause the game
        }
        else
        {
            // Teleport the player back to the starting position
            transform.position = teleportPoint.position;
            Debug.Log("Player teleported to start position.");
        }
    }

    // Functie om zwaartekracht om te draaien
    private void FlipGravity()
    {
        isGravityFlipped = !isGravityFlipped;
        rb.gravityScale *= -1;

        // De speler ondersteboven draaien als de zwaartekracht omgedraaid is
        Vector3 theScale = transform.localScale;
        theScale.y *= -1;
        transform.localScale = theScale;
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Lives: " + lifes;
        }
        else
        {
            Debug.LogError("HealthText reference is missing!");
        }
    }
}
