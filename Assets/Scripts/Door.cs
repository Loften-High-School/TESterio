using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

public string nextSceneName;

void OnTriggerEnter2D(Collider2D other)
    {

            // Check if the object this script is attached to has the "Player" tag
            if (gameObject.tag == ("Door"))
            {

                    SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
                    Debug.Log("Level comeplete!");
            

            }

        }

    }
