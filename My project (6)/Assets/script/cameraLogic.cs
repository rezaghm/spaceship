using UnityEngine;

public class cameraLogic : MonoBehaviour
{

    [Header("Target & Speed")]
    private Transform target;          // Drag your spaceship here
    public float smoothSpeed = 5f;    // Controls how fast the camera catches up
    public float deadZoneRadius = 5f; // Match the size of your CircleCollider2D radius

    // === Private References ===
    private Vector3 offset;
    private Camera mainCamera;

    void Start()
    {
        target = GameObject.FindWithTag("spaceship").transform;
        // Get the offset when the game starts
        if (target != null)
        {
            offset = transform.position - target.position;
        }
        mainCamera = Camera.main;
    }

    // Called after all Update functions are called
    void LateUpdate()
    {
        if (target == null)
            return;

        // 1. Calculate the distance between the camera's current position and the target's position
        Vector3 targetPosition = target.position;
        Vector3 cameraPosition = transform.position;

        // Ensure Z is handled correctly for 2D, keeping the camera's Z depth
        targetPosition.z = cameraPosition.z;

        float distance = Vector3.Distance(targetPosition, cameraPosition);

        // 2. Dead Zone Check: Only move the camera if the spaceship is outside the dead zone
        if (distance > deadZoneRadius)
        {
            // Calculate the desired position (where the camera wants to go)
            Vector3 desiredPosition = targetPosition + offset;

            // 3. Smooth Movement (LERP)
            // Use Lerp to move the camera from its current position towards the desired position.
            // A smaller smoothSpeed value makes the movement slower and smoother.
            Vector3 smoothedPosition = Vector3.Lerp(cameraPosition, desiredPosition, smoothSpeed * Time.deltaTime);

            // 4. Apply the smoothed position
            transform.position = smoothedPosition;
        }
    }
}
