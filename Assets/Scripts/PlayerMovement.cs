using UnityEngine;
using UnityEngine.InputSystem;

public class Playermovement : MonoBehaviour
{
private Rigidbody2D rb2d;
public Rigidbody2D rb;
public bool left = false;
public bool right = false;
public int jumps = 0;
public int WallJumps =0;
public CameraScript targetScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetScript = GameObject.Find("camera").GetComponent<CameraScript>();
    }


    // Update is called once per frame
    void Update()
    {
                Vector2 moveValue = InputSystem.actions.FindAction("Move").ReadValue<Vector2>(); 
        transform.Translate(moveValue.x * Time.deltaTime * 10.0f, 0, 0);

        if(jumps <= 1)
        {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * 17.5f, ForceMode2D.Impulse);
            jumps ++;
        }
         if(Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * 17.5f, ForceMode2D.Impulse);
            jumps ++;
        }
/*          if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * 17.5f, ForceMode2D.Impulse);
            jumps ++;
        }
*/      }
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
/*         if(Input.GetKeyDown(KeyCode.Q) && left == true && right == false)
        {
            rb.AddForce(Vector2.left * 17.5f);
        }
        if(Input.GetKeyDown(KeyCode.Q) && right == true && left == false)
        {
            rb.AddForce(Vector2.right * 17.5f);
        }
*/
    }

    void OnTriggerEnter2D(Collider2D otherObject)
        {
            if (otherObject.gameObject.CompareTag("Floor"))
            {
                    jumps = 0;
                    WallJumps = 0;
            }
           if (otherObject.gameObject.CompareTag("Left Wall"))
            {

            }
             if (otherObject.gameObject.CompareTag("Right Wall"))
            {
                
            }
        }
    void OnTriggerExit2D(Collider2D otherObject)
    {
  if (otherObject.gameObject.CompareTag("Left Wall"))
            {
                WallJumps = 0;
                jumps = 1;
                if(WallJumps >= 1)
                {
                    if(Input.GetKeyDown(KeyCode.W))
                    {
                    rb.AddForce(Vector2.right * 17.5f, ForceMode2D.Impulse);
                    WallJumps ++;
                    }
                }
            }
             if (otherObject.gameObject.CompareTag("Right Wall"))
            {
                
            }
            if (otherObject.gameObject.CompareTag("1-1 end marker"))
            {
                transform.position = new Vector3(-180.49f, -54.28f, 0f);
                GetComponent<Camera>().transform.position = new Vector3(-180.49f, -54.28f, 0f);
            }
    }
    
}
