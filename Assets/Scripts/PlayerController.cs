 using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerController: MonoBehaviour
{
    [Header("Health & Safety")]
    public int maxHealth = 100;
    private int currentHealth;
    public float invulnerabilityDuration = 3f;
    private bool isInvulnerable = false;
    private bool isDead = false;


    [Header("UI & Visuals")]
    public TextMeshProUGUI healthText;
    private SpriteRenderer spriteRenderer;


    // ... (Keep your Movement, Music, and Brightness variables here) ...


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        UpdateHealthUI();
        // ... (Keep the rest of your Start logic) ...
    }


    public void TakeDamage(int amount)
    {
        // If the player is dead OR currently in the 3-second safety window, EXIT
        if (isDead || isInvulnerable) return;


        currentHealth -= amount;
        UpdateHealthUI();


        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            // Start the 3 seconds of safety
            StartCoroutine(BecomeInvulnerable());
        }
    }


    private IEnumerator BecomeInvulnerable()
    {
        isInvulnerable = true;
        Debug.Log("Player is now safe for 3 seconds!");


        // Visual Flicker Effect
        float timer = 0;
        float flickerSpeed = 0.1f;


        while (timer < invulnerabilityDuration)
        {
            // Toggle transparency (Alpha) between 0.2 and 1.0
            Color c = spriteRenderer.color;
            c.a = (c.a == 1f) ? 0.2f : 1f;
            spriteRenderer.color = c;


            yield return new WaitForSeconds(flickerSpeed);
            timer += flickerSpeed;
        }


        // Reset to fully visible and vulnerable
        Color finalColor = spriteRenderer.color;
        finalColor.a = 1f;
        spriteRenderer.color = finalColor;
       
        isInvulnerable = false;
        Debug.Log("Safety over! Player can take damage again.");
    }


    void UpdateHealthUI()
    {
        if (healthText != null) healthText.text = "HP: " + currentHealth;
    }


    void Die()
    {
        isDead = true;
        spriteRenderer.color = Color.red; // Visual cue for death
        StartCoroutine(RestartScene());
    }


    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("GameOver");
    }
   
    // ... (Keep your Movement and Settings methods below) ...
}