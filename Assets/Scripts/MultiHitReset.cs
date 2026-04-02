using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class MultiHitReset : MonoBehaviour
{
    public int maxHits = 2; // The number of hits before reset
    private int currentHits = 0; // Tracks the current number of hits

    // This function is called when another collider enters a trigger collider attached to this object.
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has the "Enemy" tag
        if (other.CompareTag("Enemy"))
        {
            // Check if the object this script is attached to has the "Player" tag
            if (gameObject.CompareTag("Player"))
            {
                currentHits++; // Increment the hit counter
                Debug.Log("Player hit! Current hits: " + currentHits);

                // If the current hits reach or exceed the maximum allowed hits
                if (currentHits >= maxHits)
                {
                    Debug.Log("Max hits reached! Resetting...");
                    ResetObjectAndHits(); // Call the reset function
                }
            }
        }
    }

    // Resets the object and the hit counter
    void ResetObjectAndHits()
    {
        // You can customize the reset behavior here.
        // Examples:
        // 1. Reload the current scene:
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // 2. Reset position to a starting point:
        // transform.position = new Vector3(0, 0, 0); // Example reset position

        // 3. Reset other player-specific states (e.g., health, power-ups):
        // PlayerHealth playerHealth = GetComponent<PlayerHealth>();
        // if (playerHealth != null)
        // {
        //     playerHealth.ResetHealth();
        // }

        currentHits = 0; // Reset the hit counter
    }
}

