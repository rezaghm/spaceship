using UnityEngine;

public class NewMovement : MonoBehaviour
{
    public float thrustForce = 15f;
    public float maxSpeed = 10f;
    [SerializeField]
    private Rigidbody2D rb;
    
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        float moveY = Input.GetAxisRaw("Vertical");   // W/S or Up/Down


        Vector2 movementDirection = new Vector2(moveX, moveY).normalized;
    }


    void FixedUpdate()
    {
        
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        float moveY = Input.GetAxisRaw("Vertical");   // W/S or Up/Down


        Vector2 movementDirection = new Vector2(moveX, moveY).normalized;

        
        
            // Add a force in the direction of the input
            rb.AddForce(movementDirection * thrustForce);
        

        // --- 3. Max Velocity Control (Clamping) ---
        // If the ship is moving faster than maxSpeed, clamp the velocity
        // We check the squared magnitude (sqrMagnitude) because it avoids a slow square root calculation
        if (rb.linearVelocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            // Clamp the magnitude to maxSpeed while keeping the current direction
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }

       



    }
}
