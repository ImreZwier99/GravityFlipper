using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingScript : MonoBehaviour
{
    public Transform teleportPoint;

    private void Start()
    {
        if (teleportPoint == null)
        {
            // If no teleport point is assigned, use the current position of the player object
            teleportPoint = GameObject.FindWithTag("TeleportPoint").transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = teleportPoint.position;
            // Optionally, reset any necessary player states here
            Debug.Log("Player teleported back to start!");
        }
    }
}
