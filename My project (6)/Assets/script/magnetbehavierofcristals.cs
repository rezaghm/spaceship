using UnityEngine;

public class magnetbehavierofcristals : MonoBehaviour
{
    [Header("Magnet Settings")]
    
    public float pullRadius = 5f;       // How close the player needs to be
    public float pullSpeed = 8f;        // How fast the gem flies
    public float acceleration = 2f;     // How much the gem speeds up as it flies

    private Transform playerTransform;
    private bool isBeingPulled = false;

    void Start()
    {
        // 1. Find the player once at the start using the tag
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        if (playerTransform == null) return;

        // 2. Calculate the distance between the gem and the player
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        // 3. If within radius, start the "pull"
        if (distanceToPlayer <= pullRadius)
        {
            isBeingPulled = true;
        }

        if (isBeingPulled)
        {
            // Increase speed over time for a "snappy" feel
            pullSpeed += acceleration * Time.deltaTime;

            // Move the gem towards the player
            transform.position = Vector2.MoveTowards(
                transform.position,
                playerTransform.position,
                pullSpeed * Time.deltaTime
            );
        }
    }
}
