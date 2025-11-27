using UnityEngine;

public class NewMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    [SerializeField]
    private Rigidbody2D rb;
    
    void Start()
    {
        
    }


    void FixedUpdate()
    {
        
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        float moveY = Input.GetAxisRaw("Vertical");   // W/S or Up/Down


        Vector2 movementDirection = new Vector2(moveX, moveY).normalized;

        // 2. Use AddForce to apply continuous push
        // Use ForceMode.Force (default) for continuous acceleration
        if (movementDirection.magnitude > 0.1f)
        {
            rb.AddForce(movementDirection * movementSpeed * 10f); // Multiply by a factor (e.g., 10) to get a similar feeling speed
        }

        // Optional: Add code to limit max speed if AddForce makes it too fast
        if (rb.linearVelocity.magnitude > movementSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * movementSpeed;
        }
        //



    }
}
