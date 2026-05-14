using UnityEngine;

public class GlassTopHitboxScript : MonoBehaviour
{
    [SerializeField] GameObject Glass;
    public PlayerMovement playerMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            if (playerMovement.slamming == true || playerMovement.pistoned ==true)
            {
                Debug.Log("Glass shattered");
                Glass.transform.position = new Vector3(-1790.8359f, 6.79312f, 0.0f);
            }
        }
    }
}
