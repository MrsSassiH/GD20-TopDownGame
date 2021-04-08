using UnityEngine;

public class CarController : MonoBehaviour
{
    [Tooltip("Movement Speed In Meters per Second")]
    public float movementSpeed = 0.1f;

    public float steering = 0.1f;

    public KeyCode moveForwardKey;
    public KeyCode reverseKey;
    public KeyCode rightKey;
    public KeyCode leftKey;


    void Update()
    {

        bool forward = UnityEngine.Input.GetKey(moveForwardKey);
        bool reverse = UnityEngine.Input.GetKey(reverseKey);
        bool right = UnityEngine.Input.GetKey(rightKey);
        bool left = UnityEngine.Input.GetKey(leftKey);

        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        //Movement forward
        if(forward)
        {
            rigidbody.AddForce((Vector2)(transform.up * movementSpeed));
        }
        //Movement backwards
        if(reverse)
        {
            rigidbody.AddForce((Vector2)(-transform.up * movementSpeed));
        }
        //Steering right
        if(right)
        {

            rigidbody.rotation += steering * rigidbody.velocity.magnitude;
            // The cars speed and direction - rigidbody.velocity.magnitude

        }
        //Steering left
        if(left)
        {
            rigidbody.rotation -= steering * rigidbody.velocity.magnitude;
        }

    }
}
