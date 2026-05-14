using UnityEngine;

public class Pistonscript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if(otherObject.gameObject.CompareTag("Player"))
        {
            rb.AddForce(Vector2.right * 15.0f, ForceMode2D.Impulse);
            if(gameObject.CompareTag(""))
            {

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
