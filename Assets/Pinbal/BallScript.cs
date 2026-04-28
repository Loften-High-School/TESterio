using UnityEngine;
using TMPro;
public class BallScript : MonoBehaviour
{ 
  public int randomnumber;
  public float Speed = 1f;
  public string CheckSpeed;
  public float randomForceX;
  public float randomForceY;
  public int randomDirecion;
  public float SpeedCap = 3;
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
    
    public void ballForce()
    {
       if ( Speed == 0);
         {
        randomnumber = Random.Range(0, 4);
        if (randomnumber == 0)
        {
        randomForceX = -6.4f;
        }
        if (randomnumber == 1)
         {
        randomForceX = 3.5f;
         }
        if (randomnumber == 2)
        {
        randomForceY = 1f;
        }
        if (randomnumber == 3)
      {
        randomForceY = -1f;
      }
      if (randomnumber == 4)
      {
        randomForceX = -3.5f;
      }

         }
    }
    
}

