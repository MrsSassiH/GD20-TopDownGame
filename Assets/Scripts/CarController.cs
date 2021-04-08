using UnityEngine;

public class CarController : MonoBehaviour
{
    [Tooltip("Movement Speed In Meters per Second")]
    public float movementSpeed = 0.1f;

    [Tooltip("Rotation Speed In Degrees per Second")]
    public float rotationSpeed = 180;

    public KeyCode moveForwardKey;
    public KeyCode reverseKey;
    public KeyCode rightKey;
    public KeyCode leftKey;

    public GameObject driver;

    void Update()
    {
        bool forward = UnityEngine.Input.GetKey(moveForwardKey);
        bool reverse = UnityEngine.Input.GetKey(reverseKey);
        bool right = UnityEngine.Input.GetKey(rightKey);
        bool left = UnityEngine.Input.GetKey(leftKey);

        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        if(forward)
        {
            rigidbody.AddForce((Vector2)(transform.up * movementSpeed));
        }
        if (reverse)
        {
            rigidbody.AddForce((Vector2)(-transform.up * movementSpeed));
        }
        if (right)
        {
            transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime * rigidbody.velocity.magnitude);
        }
        if (left)
        {
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime * rigidbody.velocity.magnitude);
        }

        /* if (exit)
         * set the driver's position to our own position
         * activate the driver
         * disable ourselves (this script) 
         */
    }
}
