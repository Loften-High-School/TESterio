using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
private Rigidbody2D rb2d;
public Rigidbody2D rb;
public bool left = false;
public bool right = false;
public int jumps = 0; //variable that determines how many times the player can jump
public int WallJumps =0; //supposed to determine amount of times the player can jump off a wall but I believe it doesn't do anything at the moment
public int SJumps = 0; //determines how many super jumps the player can do, only occurs when slamming into the floor
public bool slamming = false; //states that the player is currently slamming
public CameraScript targetScript; //to move the camera when the player goes to the next room
public bool Landmined = false; //turns on when the player touches a landmine
public GameObject Glass1; 
public GameObject Glass2;
public GameObject Glass3;
public GameObject Glass4;
public bool pistoned = false; //turns on when the player touches a piston
/*


PLEASE USE THE NEW INPUT SYSTEM FOR MOVEMENT,
THE CODE IS IN PLACE BUT COMMENTED OUT, 
IF YOU HAVE ANY QUESTIONS PLEASE ASK ME
-BAEZ

*/


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }


    // Update is called once per frame
    void Update()
    {
                Vector2 moveValue = InputSystem.actions.FindAction("Move").ReadValue<Vector2>(); //moves the player when they press A, D, or the left & right arrow keys
        transform.Translate(moveValue.x * Time.deltaTime * 10.0f, 0, 0);


        if(jumps <= 1)
        {
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) //makes the player jump when they press the up arrow or W
        {
            slamming = false; //ensures that slamming is off when the player starts jumping
            rb.linearVelocity = Vector2.zero; //stops all sideways momentum when player starts jumping
            rb.AddForce(Vector2.up * 20.0f, ForceMode2D.Impulse); //pushes the player up to actually make the player "jump"
            jumps ++; //adds 1 to the jumps variable
        }

/*          if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * 17.5f, ForceMode2D.Impulse);
            jumps ++;
        }
*/      }
        if(SJumps <=0) //if the SJumps variable is less than or equal to 0 then the following stuff will happen
        {
             if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) //does a "Super Jump" if you press W or up arrow while SJumps is less than or equal to 0
             {
                rb.linearVelocity = Vector2.zero; //sets sideways momentum to 0
                pistoned = false; //sets pistoned variable to false
                slamming = false; //sets slamming variable to false
                Landmined = false; //sets landmined variable to false
                rb.AddForce(Vector2.up * 30.0f, ForceMode2D.Impulse); //shoots the player into the air
                jumps = 1; //sets jumps variable to 1
                SJumps = 1; //sets SJumps to 1 and effectively putting it on cooldown
             }
        }
         if(Input.GetKeyDown(KeyCode.S)) //starts slamming when the S key is press
        {
            rb.linearVelocity = Vector2.zero; //sets all sideways momentum to 0
            rb.AddForce(Vector2.down * 30.0f, ForceMode2D.Impulse); //slams the player into the ground
            slamming = true; //sets slamming to true
            Landmined = false; //sets landmined to false
            pistoned = false; //sets pistoned to false
        }
         if(Input.GetKeyDown(KeyCode.DownArrow)) //starts slamming when the down arrow is pressed (I don't know why there's two different slamming script things but I'll fix it when my Unity editor isn't screwed up)
        {
            rb.linearVelocity = Vector2.zero; //sets sideways momentum to 0
            rb.AddForce(Vector2.down * 40.0f, ForceMode2D.Impulse); //slams the player into the ground
            slamming = true; //sets slamming to true
            Landmined = false; //sets landmined to false
            pistoned = false; //sets pistoned to false
        }
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) //old and obsolete script that attempted to add dashing into the game
        {
            left = true; //would set the left variable to true
            right = false; //would set the right variable to false
            pistoned = false; //sets pistoned to false
        }
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) //old and obsolete script that attempted to add dashing into the game
        {
            left = false; //would set left to false
            right = true; //would set right to true
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
                    pistoned = false;
            }
            if (otherObject.gameObject.CompareTag("ground slam window"))
            {
                pistoned = false;
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
                pistoned = false;
                if(slamming == false)
                {  
                Landmined = true;
                transform.position = new Vector3(-1800.49f, -24.28f, 0f);
                targetScript.GetComponent<Camera>().transform.position = new Vector3(-172.5f, -13.0f, -10.0f);
                StartCoroutine(ExecuteAfterTime(2.0f));
                IEnumerator ExecuteAfterTime(float time) 
                {
                yield return new WaitForSeconds(time);
                    Debug.Log("The timer ran out");
                    transform.position = new Vector3(-180.49f, -24.28f, 0f);
                }
                }
                if(slamming == true)
                {
                rb.linearVelocity = Vector2.zero;
                rb.AddForce(Vector2.up * 40.0f, ForceMode2D.Impulse);
                slamming = false;
                Landmined = true;
                }
            }
            if (otherObject.gameObject.CompareTag("landmine trigger 1-4"))
            {
                pistoned = false;
                if(slamming == false)
                {  
                Landmined = true;
                transform.position = new Vector3(-1800.49f, 10.28f, 0f);
                targetScript.GetComponent<Camera>().transform.position = new Vector3(-172.5f, 17.0f, -10.0f);
                StartCoroutine(ExecuteAfterTime(2.0f));
                IEnumerator ExecuteAfterTime(float time) 
                {
                yield return new WaitForSeconds(time);
                    Debug.Log("The timer ran out");
                    transform.position = new Vector3(-180.49f, 10.28f, 0f);
                    Glass1.transform.position = new Vector3(-179.8359f, 6.79312f, 0.0f); //moves glass1 back on screen when respawning
                    Glass2.transform.position = new Vector3(-179.8359f, 14.41f, 0.0f);  //moves glass2 back on screen when respawning

                }
                }
                if(slamming == true)
                {
                rb.linearVelocity = Vector2.zero;
                rb.AddForce(Vector2.up * 45.0f, ForceMode2D.Impulse);
                slamming = false;
                Landmined = true;
                }
            }
            if (otherObject.gameObject.CompareTag("landmine trigger 1-5"))
            {
                pistoned = false;
                if(slamming == false)
                {  
                Landmined = true;
                transform.position = new Vector3(-1800.49f, 10.28f, 0f);
                targetScript.GetComponent<Camera>().transform.position = new Vector3(-172.5f, 47.0f, -10.0f);
                StartCoroutine(ExecuteAfterTime(2.0f));
                IEnumerator ExecuteAfterTime(float time) 
                {
                yield return new WaitForSeconds(time);
                    Debug.Log("The timer ran out");
                    transform.position = new Vector3(-180.49f, 35.28f, 0f);
                    Glass4.transform.position = new Vector3(-168.98f, 40f, 0.0f); //moves glass4 back on screen when respawning
                }
                }
                if(slamming == true)
                {
                rb.linearVelocity = Vector2.zero;
                rb.AddForce(Vector2.up * 45.0f, ForceMode2D.Impulse);
                slamming = false;
                Landmined = true;
                }
            }
            if (otherObject.gameObject.CompareTag("Glass hitbox"))
            {
                if(slamming == false)
                {
                    jumps = 0;
                    WallJumps = 0;
                    Landmined = false;
                }
                if(slamming == true)
                {
                    Landmined = false;
                }
            }
            if(otherObject.gameObject.CompareTag("Piston Trigger"))
            {
                Debug.Log("Get Piston-ed nerd");
                rb.linearVelocity = Vector2.zero;
                rb.AddForce(Vector2.right * 25.0f, ForceMode2D.Impulse);
                pistoned = true;
            }
            if(otherObject.gameObject.CompareTag("Piston TriggerR"))
            {
                Debug.Log("Get Piston-ed nerd");
                rb.linearVelocity = Vector2.zero;
                rb.AddForce(Vector2.right * -100.0f, ForceMode2D.Impulse);
                pistoned = true;
            }
        }
    void OnTriggerExit2D(Collider2D otherObject)
    {
  if (otherObject.gameObject.CompareTag("Left Wall"))
            {
                pistoned = false;
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
                pistoned = false;
                jumps = 1;
            }
            if (otherObject.gameObject.CompareTag("1-1 end marker"))
            {
                transform.position = new Vector3(-180.49f, -54.28f, 0f);
                targetScript.GetComponent<Camera>().transform.position = new Vector3(-172.5f, -43.0f, -10.0f);
//                    targetScript.GetComponent<tutorialText>().transform.position = new Vector3(-9f, -350f, 0f);
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
                transform.position = new Vector3(-180.49f, 35.28f, 0f);
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
