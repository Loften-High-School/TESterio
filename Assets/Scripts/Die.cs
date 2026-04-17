
using UnityEngine;
using UnityEngine.SceneManagement;

public class Die : MonoBehaviour
{

public int Playerhealth = 1;
    public int maxHits = 2; // The number of hits before reset
    private int currentHits = 0; // Tracks the current number of hits

void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the colliding object has the "Enemy" tag
        if (other.gameObject.tag == ("Enemy"))
        {
            // Check if the object this script is attached to has the "Player" tag
            if (gameObject.tag == ("Player"))
            {
                currentHits++; // Increment the hit counter
                Debug.Log("Player hit! Current hits: " + currentHits);

                // If the current hits reach or exceed the maximum allowed hits
                if (currentHits >= maxHits)
                { 
                    SceneManager.LoadScene("SampleScene");
                }

            }

        }


    }


   
void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has the "Enemy" tag
        if (other.gameObject.tag == ("Enemy"))
        {
            // Check if the object this script is attached to has the "Player" tag
            if (gameObject.tag == ("Player"))
            {
                currentHits++; // Increment the hit counter
                Debug.Log("Player hit! Current hits: " + currentHits);

                // If the current hits reach or exceed the maximum allowed hits
                if (currentHits >= maxHits)
                { 
                    SceneManager.LoadScene("SampleScene");
                }

            }

        }


    }

}
