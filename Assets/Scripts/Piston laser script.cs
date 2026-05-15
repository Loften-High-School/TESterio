using UnityEngine;
using System.Collections;

public class Pistonlaserscript : MonoBehaviour
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
            transform.position = new Vector3(-100f, 0f, 0f);
            StartCoroutine(ExecuteAfterTime(5.0f));
                IEnumerator ExecuteAfterTime(float time) 
                {
                yield return new WaitForSeconds(time);
                    Debug.Log("The timer ran out");
                    transform.position = new Vector3(100f, 0f, 0f);
                }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
