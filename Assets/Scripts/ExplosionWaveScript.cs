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

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("landmine trigger")) 
        { 
        particleSystem.Play();
        } 
        
        
        
        
    }
}
