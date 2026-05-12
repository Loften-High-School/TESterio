using UnityEngine;

public class spikescript : MonoBehaviour
{
    // Start is called before the first execution of Update of Update after the MonoBehaviour is created
    void Start()
    {

    
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if(otherObject .gameObject.CompareTag("spikes lvl 1"))
        {
            transform.position = new Vector3(-14.41f, 2.82f, 0.0f);
        }
        if(otherObject .gameObject.CompareTag("level 1 end"))
        {
            transform.position = new Vector3(1449.08f, 220.17f, 0.0f);
        }
        if(otherObject .gameObject.CompareTag("spikes lvl 2"))
        {
            transform.position = new Vector3(1449.08f, 220.17f, 0.0f);
        }
    }
}