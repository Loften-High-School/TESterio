using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject container;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            container.SetActive(true);
            Time.timeScale = 0;
        }
    }


    public void ResumeButton()
    {
        container.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainmenuButton()
    {
         SceneManager.LoadScene("Menu");
    }
}
