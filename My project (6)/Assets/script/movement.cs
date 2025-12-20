using Unity.VisualScripting;
using UnityEngine;

public class movement : MonoBehaviour
{
    [Header("ship power")]
    
    [SerializeField] private float shipRotationspeed = 10f;

    //private Rigidbody2D shipRigidbody;
    


    private bool isAlive = true;



    // Update is called once per frame
    private void Update()
    {
        if (isAlive == true)
        {
           
            
            Handle2DAiming();
        }
    }

    

    
    private void Handle2DAiming()
    {
        
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f; 

        
        Vector3 direction = mouseWorldPosition - transform.position;

        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle - 90f);

        
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            shipRotationspeed * Time.deltaTime
        );

        
    }
}
