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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag == ("Player"))
        {
        randomnumber = Random.Range(4, 8);
        if (randomnumber == 4)
        {
            SceneManager.LoadScene("Secret1");
        }
        if (randomnumber == 5)
        {
          SceneManager.LoadScene("Secret2");
        }
        if (randomnumber == 6)
        {
            SceneManager.LoadScene("Secret3");
        }
        if (randomnumber == 7)
        {
            SceneManager.LoadScene("Secret4");
        }
        if (randomnumber == 8)
        {
            SceneManager.LoadScene("Secret5");
        }
        }
        
    }
}
