using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    
    public float speed = 5f;

    
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        
        if (playerTransform != null)
        {
            
            Vector2 targetPosition = playerTransform.position;

            
            Vector2 currentPosition = transform.position;

            
            transform.position = Vector2.MoveTowards(
                currentPosition,
                targetPosition,
                speed * Time.deltaTime
            );
        }
    }

}
