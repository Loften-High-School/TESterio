using UnityEngine;
using TMPro;
public class BallScript : MonoBehaviour
{ 

  public float startingSpeed;
  public Rigidbody2D rb;
  public int randomnumber;
  public float Speed = 1f;
  public float SpeedCap = 3;
  private int score;
  public TextMeshProUGUI ScoreText;
  public TextMeshProUGUI MessageText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      ScoreText.text = "Score: 0";
      MessageText.text = "";

      // message text//

      bool isRight = UnityEngine.Random.value >= 0.5;
      
      float xVelocity = -1f;

      if (isRight == true)
      {
        xVelocity = 1f;
      }

      float yVelocity = UnityEngine.Random.Range(-1, 1);

      rb.linearVelocity = new Vector2(xVelocity * startingSpeed, yVelocity * startingSpeed);
     
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

