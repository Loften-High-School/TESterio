using UnityEngine;
using TMPro;
public class BallScript : MonoBehaviour
{

  private int score;
  public TextMeshProUGUI ScoreText;
  public TextMeshProUGUI MessageText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      ScoreText.text = "Score: 0";
      MessageText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called when this object collides with another
    void OnCollisionEnter2D(Collision2D AnyOtherObject)
    {
        score++;  // increase the current score
   ScoreText.text = "Score: " + score;  // update the display
    }
    
    void OnTriggerEnter2D(Collider2D GrayTriggerObject)
    {

    }
}

