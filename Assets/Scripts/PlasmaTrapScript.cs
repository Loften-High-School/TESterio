using UnityEngine;
using System.Collections;

public class PlasmaTrapScript : MonoBehaviour
{
    private PlayerMovement playerMovement;
    
    [SerializeField] ParticleSystem particleSystemTop1;
    [SerializeField] ParticleSystem particleSystemTop2;
    [SerializeField] ParticleSystem particleSystemTop3;
    [SerializeField] ParticleSystem particleSystemBottom1;
    [SerializeField] ParticleSystem particleSystemBottom2;
    [SerializeField] ParticleSystem particleSystemBottom3;
    [SerializeField] ParticleSystem particleSystemSecTop;
    [SerializeField] ParticleSystem particleSystemSecBottom;
    public bool CannonActive = false;
    public GameObject HitboxOfDeath;
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
            particleSystemSecTop.Play();
            particleSystemSecBottom.Play();
        StartCoroutine(ExecuteAfterTime(0.75f));
            IEnumerator ExecuteAfterTime(float time) 
            {
                yield return new WaitForSeconds(time);
                HitboxOfDeath.transform.position = new Vector3(-164.9606f, 49.7798f, 0.0f);
                CannonActive = true;
                Debug.Log("Get Plasma Cannon-ed bozo");
            particleSystemTop1.Play();
            particleSystemTop2.Play();
            particleSystemTop3.Play();
            particleSystemBottom1.Play();
            particleSystemBottom2.Play();
            particleSystemBottom3.Play();
                StartCoroutine(ExecuteAfterTime(1.75f));
                IEnumerator ExecuteAfterTime(float time) 
                {
                yield return new WaitForSeconds(time);
                HitboxOfDeath.transform.position = new Vector3(-207.4206f, 49.7798f, 0.0f);
                CannonActive = false;
                }
            }
        } 
            
    }
}
