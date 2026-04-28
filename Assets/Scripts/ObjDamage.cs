using UnityEngine;


public class ObjDamage : MonoBehaviour
{
    public int damageAmount = 20;


    // This works if the Hazard has "Is Trigger" CHECKED
    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleCollision(other.gameObject);
    }


    // This works if the Hazard is a solid wall (Is Trigger UNCHECKED)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision.gameObject);
    }


    private void HandleCollision(GameObject victim)
    {
        // Look for the PlayerController script on the object we touched
        PlayerController player = victim.GetComponent<PlayerController>();


        if (player != null)
        {
            player.TakeDamage(damageAmount);
        }
    }
}

