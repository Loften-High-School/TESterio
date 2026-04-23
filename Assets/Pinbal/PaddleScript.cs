using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            // get the "Move" X and Y values
        Vector2 moveValue = InputSystem.actions.FindAction("Move").ReadValue<Vector2>(); 
        transform.Translate(moveValue.x * Time.deltaTime, 0, 0);  // move only in the X direction
    }
}
