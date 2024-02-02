using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// deze enemy schiet projectielen.


public class Distance_Enemy : MonoBehaviour
{
    public float shootingRange = 5f;  // The range at which the enemy starts shooting
    public float shootingCooldown = 2f;  // Cooldown between shots
    public GameObject projectilePrefab;  // The projectile prefab to be shot

    private Transform player;  // Reference to the player's transform
    private Vector2 lastKnownPlayerPosition;  // Store the last known player position
    private float lastShotTime;  // The time when the last shot was fired

    void Start()
    {
        // Find the player at the start
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            Debug.LogError("Player not found!");
        }
    }

    void Update()
    {
        // Check if the player is in range
        if (Vector2.Distance(transform.position, player.position) <= shootingRange)
        {
            // Update the last known player position
            lastKnownPlayerPosition = player.position;

            // Check if enough time has passed since the last shot
            if (Time.time - lastShotTime >= shootingCooldown)
            {
                // Shoot a projectile
                Shoot();
                lastShotTime = Time.time;  // Update the last shot time
            }
        }
    }

    void Shoot()
    {
        // Instantiate a projectile at the enemy's position
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Calculate the direction from the enemy to the last known player position
        Vector2 direction = (lastKnownPlayerPosition - (Vector2)transform.position).normalized;

        // Set the velocity of the projectile to move towards the last known player position
        projectile.GetComponent<Rigidbody2D>().velocity = direction * 20f;  // Adjust the speed as needed
    }
}
