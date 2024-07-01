using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // De snelheid van het bewegen
    public float climbSpeed = 3f; // De snelheid van het beklimmen en afdalen
    public float jumpForce = 10f; // De kracht van de sprong

    public GameObject deathMenu;

    public int lifes = 3;

    private bool isGravityFlipped = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Bewegen op de grond
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

        // Zwaartekracht omdraaien met pijltje omhoog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FlipGravity();
        }

        if (lifes <= 0)
        {
            deathMenu.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            lifes--;
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
}