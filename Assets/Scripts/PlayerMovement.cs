using UnityEngine;
using UnityEngine.InputSystem;

public class Playermovement : MonoBehaviour
{
public Rigidbody2D rb;
public bool left = false;
public bool right = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
                Vector2 moveValue = InputSystem.actions.FindAction("Move").ReadValue<Vector2>(); 
        transform.Translate(moveValue.x * Time.deltaTime * 10.0f, 0, 0);

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * 17.5f, ForceMode2D.Impulse);
        }
         if(Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * 17.5f, ForceMode2D.Impulse);
        }
         if(Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(Vector2.down * 17.5f, ForceMode2D.Impulse);
        }
         if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.AddForce(Vector2.down * 17.5f, ForceMode2D.Impulse);
        }
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            left = true;
            right = false;
        }
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            left = false;
            right = true;
        }
         if(Input.GetKeyDown(KeyCode.Q) && left == true && right == false)
        {
            rb.AddForce(Vector2.left * 17.5f);
        }
        if(Input.GetKeyDown(KeyCode.Q) && right == true && left == false)
        {
            rb.AddForce(Vector2.right * 17.5f);
        }
    }

}
