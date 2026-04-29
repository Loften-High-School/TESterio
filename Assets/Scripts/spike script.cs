using UnityEngine;

public class spikescript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void onTriggerEnter2d()
    {
        if(otherObject.gameObject.CompareTag("spikes lvl 1"))
        {
            transform.position = new Vector3(-14.41f, 2.82f, 0.0f);
        }
    }
}
