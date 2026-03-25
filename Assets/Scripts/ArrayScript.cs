using UnityEngine;

public class ArrayScript : MonoBehaviour
{
    public string[] playerItems;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Debug.Log("The first item is: " + playerItems[0]);
        Debug.Log("The second item is: " + playerItems[1]);
        Debug.Log("The rizzler item is: " + playerItems[2]);
        Debug.Log("The sigma item is: " + playerItems[3]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
