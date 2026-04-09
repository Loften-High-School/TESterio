using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

public string nextSceneName;

void OnCollisionEnter2D(Collision2D other)
    {

            // Check if the object this script is attached to has the "Player" tag
            if (gameObject.tag == ("Player"))
            {

                    SceneManager.LoadScene("Level2");
                    SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
            

            }

        }

    }
