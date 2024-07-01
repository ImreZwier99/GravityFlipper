using UnityEngine;
using UnityEngine.SceneManagement; // Import the SceneManagement namespace

public class LevelManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player has collided with the finish object
        if (collision.gameObject.CompareTag("Player"))
        {
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Load the next scene in the build order
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
