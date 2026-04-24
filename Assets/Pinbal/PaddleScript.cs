using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        PaddleMove("Paddle1", "Move");
        PaddleMove("Paddle2", "Move2");
        
    }


    // Update is called once per frame
    public void PaddleMove(string whichPaddle, string whichMove)
    {
         if (gameObject.tag == (whichPaddle))
          {
            // get the "Move" X and Y values
        Vector2 moveValue = InputSystem.actions.FindAction(whichMove).ReadValue<Vector2>(); 
        transform.Translate(0, moveValue.y * Time.deltaTime * 4f, 0);  // move only in the Y direction
          }
    }
/*
    public void PaddleTwo()
    {
        if (gameObject.tag == ("Paddle2"))
        {
        Vector2 moveValue = InputSystem.actions.FindAction("Move2").ReadValue<Vector2>(); 
        transform.Translate(0, moveValue.y * Time.deltaTime * 4f, 0);  // move only in the Y direction
        }

    }

*/
}
