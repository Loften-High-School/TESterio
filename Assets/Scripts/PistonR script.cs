using UnityEngine;
using System.Collections;

public class PistonRscript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Rigidbody2D rb;
    public GameObject laser1;
    public GameObject laser2;
    public GameObject laser3;
    public GameObject laser4;
    public GameObject laser5;
    public GameObject laser6;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if(otherObject.gameObject.CompareTag("Player"))
        {
            rb.AddForce(Vector2.right * 1400.0f, ForceMode2D.Impulse);
            StartCoroutine(ExecuteAfterTime(0.5f));
                IEnumerator ExecuteAfterTime(float time) 
                {
                yield return new WaitForSeconds(time);
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
                rb.linearVelocity = new Vector2(-1, rb.linearVelocity.y);
                laser1.transform.position += new Vector3(110.96831f, 16.11741f, 0f);
                laser2.transform.position += new Vector3(111.26131f, 16.11741f, 0f);
                laser3.transform.position += new Vector3(111.5872f, 16.11741f, 0f);
                laser4.transform.position += new Vector3(112.0316f, 16.11741f, 0f);
                laser5.transform.position += new Vector3(112.5023f, 16.11741f, 0f);
                laser6.transform.position += new Vector3(112.70309f, 16.11741f, 0f);
                StartCoroutine(ExecuteAfterTime(5.0f));
                IEnumerator ExecuteAfterTime(float time) 
                    {
                yield return new WaitForSeconds(time);
                    Debug.Log("The timer ran out");
                laser1.transform.position -= new Vector3(110.96831f, 16.11741f, 0f);
                laser2.transform.position -= new Vector3(111.26131f, 16.11741f, 0f);
                laser3.transform.position -= new Vector3(111.5872f, 16.11741f, 0f);
                laser4.transform.position -= new Vector3(112.0316f, 16.11741f, 0f);
                laser5.transform.position -= new Vector3(112.5023f, 16.11741f, 0f);
                laser6.transform.position -= new Vector3(112.70309f, 16.11741f, 0f);
                    }
                }    
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}