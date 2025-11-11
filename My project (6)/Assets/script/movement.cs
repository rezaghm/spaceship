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
    private bool isnegetiveAcceloration = false;
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
            HandleShipRorarion();
        }
    }

    private void FixedUpdate()
    {
        if (isAcceloration && isAlive)
        {
            shipRigidbody.AddForce(shipAccoleration * transform.up);
            shipRigidbody.linearVelocity = Vector2.ClampMagnitude(shipRigidbody.linearVelocity, shipMaxVlocity);

        }

        if (isnegetiveAcceloration && isAlive)
        {
            
            shipRigidbody.linearVelocity = Vector2.ClampMagnitude(shipRigidbody.linearVelocity, shipMaxVlocity * 0.2f);

        }

    }

    private void HandleShipAcceleration() {
        isAcceloration = Input.GetKey(KeyCode.W);
        isnegetiveAcceloration = Input.GetKey(KeyCode.S);
    }
    private void HandleShipRorarion() {
        if (Input.GetKey(KeyCode.A)) { 
            transform.Rotate(shipRotationspeed * Time.deltaTime *transform.forward);

        }
        else if(Input.GetKey(KeyCode.D)) {
            transform.Rotate(-shipRotationspeed * Time.deltaTime * transform.forward);
        }
    
    }
}
