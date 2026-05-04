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
public int SJumps = 0;
public bool slamming = false;
public CameraScript targetScript;

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


        if(jumps <= 1)
        {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            slamming = false;
            rb.linearVelocity = Vector2.zero;
            rb.AddForce(Vector2.up * 20.0f, ForceMode2D.Impulse);
            jumps ++;
        }
         if(Input.GetKeyDown(KeyCode.W))
        {
            slamming = false;
            rb.linearVelocity = Vector2.zero;
            rb.AddForce(Vector2.up * 20.0f, ForceMode2D.Impulse);
            jumps ++;
        }
/*          if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * 17.5f, ForceMode2D.Impulse);
            jumps ++;
        }
*/      }
        if(SJumps <=0)
        {
             if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
             {
                rb.linearVelocity = Vector2.zero;
                slamming = false;
                rb.AddForce(Vector2.up * 30.0f, ForceMode2D.Impulse);
                jumps = 1;
                SJumps = 1;
             }
        }
         if(Input.GetKeyDown(KeyCode.S))
        {
            rb.linearVelocity = Vector2.zero;
            rb.AddForce(Vector2.down * 30.0f, ForceMode2D.Impulse);
            slamming = true;
        }
         if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.linearVelocity = Vector2.zero;
            rb.AddForce(Vector2.down * 40.0f, ForceMode2D.Impulse);
            slamming = true;
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
                    SJumps = 1;
                    slamming = false;
            }
            if (otherObject.gameObject.CompareTag("ground slam window"))
            {
                if(slamming == true)
                {
                    jumps = 2;
                    WallJumps = 0;
                    SJumps = 0;
                }
            }
           if (otherObject.gameObject.CompareTag("Left Wall"))
            {

            }
             if (otherObject.gameObject.CompareTag("Right Wall"))
            {
                
            }
            if (otherObject.gameObject.CompareTag("landmine trigger"))
            {
                if(slamming == false)
                {
                transform.position = new Vector3(-180.49f, -24.28f, 0f);
                targetScript.GetComponent<Camera>().transform.position = new Vector3(-172.5f, -13.0f, -10.0f);
                }
                if(slamming == true)
                {
                rb.linearVelocity = Vector2.zero;
                rb.AddForce(Vector2.up * 40.0f, ForceMode2D.Impulse);
                slamming = false;

                }
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
                jumps = 1;
            }
            if (otherObject.gameObject.CompareTag("1-1 end marker"))
            {
                transform.position = new Vector3(-180.49f, -54.28f, 0f);
                targetScript.GetComponent<Camera>().transform.position = new Vector3(-172.5f, -43.0f, -10.0f);
            }
            if (otherObject.gameObject.CompareTag("1-2 end marker"))
            {
                transform.position = new Vector3(-180.49f, -24.28f, 0f);
                targetScript.GetComponent<Camera>().transform.position = new Vector3(-172.5f, -13.0f, -10.0f);
            }
            if (otherObject.gameObject.CompareTag("1-3 end marker"))
            {
                transform.position = new Vector3(-180.49f, 10.28f, 0f);
                targetScript.GetComponent<Camera>().transform.position = new Vector3(-172.5f, 17.0f, -10.0f);
            }
            if (otherObject.gameObject.CompareTag("1-4 end marker"))
            {
                transform.position = new Vector3(-180.49f, 40.28f, 0f);
                targetScript.GetComponent<Camera>().transform.position = new Vector3(-172.5f, 47.0f, -10.0f);
            }
            if (otherObject.gameObject.CompareTag("1-5 end marker"))
            {
                transform.position = new Vector3(-180.49f, 70.28f, 0f);
                targetScript.GetComponent<Camera>().transform.position = new Vector3(-172.5f, 77.0f, -10.0f);
            }
            if (otherObject.gameObject.CompareTag("1-6 end marker"))
            {
                transform.position = new Vector3(-180.49f, 70.28f, 0f);
                targetScript.GetComponent<Camera>().transform.position = new Vector3(-172.5f, 77.0f, -10.0f);
            }
    }
    
}
