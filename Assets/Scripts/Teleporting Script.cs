using System.Numerics;
using UnityEngine;

public class teleporter : MonoBehaviour
{
    public Transform teleportTarget;
    public Rigidbody2D player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        
        
        other.transform.position = teleportTarget.position;
        Debug.Log(other.name + " has been teleported!");
        player.linearVelocity = new UnityEngine.Vector2(0, 0);
        
    }
}