using UnityEngine;

public class CharacterDash : MonoBehaviour
{
    // Public variables to adjust the dash behavior in the Unity Inspector
    public float dashSpeed = 20f; // How fast the dash is
    public float dashDuration = 0.20f; // How long the dash lasts
    public float dashCooldown = 1f; // Time before the player can dash again

    // Private variables for state management
    private Rigidbody2D rb;
    private float dashTime;
    private float lastDashTime;
    private bool isDashing = false;

    // The direction of the dash
    private Vector2 dashDirection;

    void Start()
    {
        // Get the Rigidbody2D component when the game starts
        rb = GetComponent<Rigidbody2D>();
        
        // Safety check
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on the character. Please add one!");
            enabled = false; // Disable the script if no Rigidbody is found
        }
    }

    void Update()
    {
        // Check if the dash key (e.g., Spacebar) is pressed and the cooldown is ready
        if (Input.GetKeyDown(KeyCode.Q) && Time.time >= lastDashTime + dashCooldown)
        {
            // Get the current input direction from the arrow keys/WASD
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            // Only attempt to dash if there's an input direction
            if (horizontalInput != 0 || verticalInput != 0)
            {
                // Set the dash direction to the normalized input vector
                dashDirection = new Vector2(horizontalInput, verticalInput).normalized;
                
                // Start the dash
                StartDash();
            }
        }
    }


    void FixedUpdate()
    {
        // FixedUpdate is best for physics-based movement (like using a Rigidbody)
        if (isDashing)
        {
            // Apply the dash velocity
            rb.linearVelocity = dashDirection * dashSpeed;

            // Decrease the remaining dash time
            dashTime -= Time.fixedDeltaTime;

            // End the dash if the duration is over
            if (dashTime <= 0)
            {
                EndDash();
            }
        }
    }

    // Method to initiate the dash
    void StartDash()
    {
        isDashing = true;
        dashTime = dashDuration; // Reset the dash timer
        lastDashTime = Time.time; // Record the dash time for the cooldown
        // Optionally, you might want to stop regular movement here or change an animation state.
    }

    // Method to conclude the dash
    void EndDash()
    {
        isDashing = false;
        // Optionally, reset the velocity or set it to the normal walking speed
        rb.linearVelocity = Vector2.zero; 
        // Resetting to zero is common to stop the momentum; you'd reapply regular movement velocity in a separate script.
    }
}

