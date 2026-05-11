using UnityEngine;

public class ExplosionWaveScript : MonoBehaviour
{
    private PlayerMovement playerMovement;
    
    [SerializeField] ParticleSystem particleSystem;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        { 
        particleSystem.Play();
        } 
            
    }
}
