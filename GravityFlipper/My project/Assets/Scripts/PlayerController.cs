using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // De snelheid van het bewegen
    public float climbSpeed = 3f; // De snelheid van het beklimmen en afdalen
    public float jumpForce = 10f; // De kracht van de sprong

    public GameObject deathMenu;

    public int lifes = 3;

    void Update()
    {
        // Bewegen op de grond
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

        // Springen met de spatiebalk
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
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

    // Springfunctie
    private void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}