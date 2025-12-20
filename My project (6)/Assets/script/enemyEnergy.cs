using Unity.VisualScripting;
using UnityEngine;

public class enemyEnergy : MonoBehaviour
{
    public GameObject gemPrefab;
    public Transform playerTransform;
    public float speed = 10f;
    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }
    private void OnDestroy()
    {
       
        if (!gameObject.scene.isLoaded) return;

            SpawnGem();
        
    }

    private void SpawnGem()
    {
        if (gemPrefab != null)
        {
            // 3. Create the gem at the enemy's last position
            // Quaternion.identity means "no rotation"
            Instantiate(gemPrefab, transform.position, Quaternion.identity);
        }
    }
   
}
