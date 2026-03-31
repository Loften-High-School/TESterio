using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public float elapsedTime = 0;
    public TextMeshProUGUI timeText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeText.text = "Time: 0";
    }

    // Update is called once per frame
    void Update()
    {
        // add time since the last frame to our measure
			// of overall elapsed time
			elapsedTime += Time.deltaTime;

			// update the timeText message, converting float to int
			timeText.text = "Time: " + elapsedTime;
            //stops the game if the time reaches a certain point//
           


    }
}
