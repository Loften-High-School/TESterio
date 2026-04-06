using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class SceneRandomizer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int randomnumber;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.tag == ("Player"))
        {
        randomnumber = Random.Range(0, 4);
        if (randomnumber == 0)
        {
            SceneManager.LoadScene("Secret1");
        }
        if (randomnumber == 1)
        {
          SceneManager.LoadScene("Secret2");
        }
        if (randomnumber == 2)
        {
            SceneManager.LoadScene("Secret3");
        }
        if (randomnumber == 3)
        {
            SceneManager.LoadScene("Secret4");
        }
        if (randomnumber == 4)
        {
            SceneManager.LoadScene("Secret5");
        }
        }
        
    }
}
