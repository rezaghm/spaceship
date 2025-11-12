using Unity.VisualScripting;
using UnityEngine;

public class movement : MonoBehaviour
{
    [Header("ship power")]
    [SerializeField] private float shipAccoleration = 10f;
    [SerializeField] private float shipMaxVlocity = 10f;
    [SerializeField] private float shipRotationspeed = 10f;

    private Rigidbody2D shipRigidbody;
    private bool isAcceloration = false;
    private bool isStoped = false;


    private bool isAlive = true;


    private void Start()
    {
        shipRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isAlive == true)
        {
            HandleShipAcceleration();
            
            Handle2DAiming();
        }
    }

    private void FixedUpdate()
    {
        if (isAcceloration && isAlive)
        {
            shipRigidbody.AddForce(shipAccoleration * transform.up);
            shipRigidbody.linearVelocity = Vector2.ClampMagnitude(shipRigidbody.linearVelocity, shipMaxVlocity);

        }
        if (isStoped && isAlive)
        {
            
            shipRigidbody.linearVelocity = Vector2.ClampMagnitude(shipRigidbody.linearVelocity, shipMaxVlocity* 0.1f);

        }



    }

    private void HandleShipAcceleration() {
        isAcceloration = Input.GetKey(KeyCode.W);
        isStoped = Input.GetKey(KeyCode.Space);
        

    }
    private void HandleShipRorarion() {
        if (Input.GetKey(KeyCode.A)) { 
            transform.Rotate(shipRotationspeed * Time.deltaTime *transform.forward);

        }
        else if(Input.GetKey(KeyCode.D)) {
            transform.Rotate(-shipRotationspeed * Time.deltaTime * transform.forward);
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
