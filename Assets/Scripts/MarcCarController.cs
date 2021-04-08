using UnityEngine;

public class MarcCarController : MonoBehaviour
{
    [Tooltip("Movement Speed In Meters per Second")]
    public float movementSpeed = 0.1f;

    [Tooltip("Rotation Speed In Degrees per Second")]
    public float rotationSpeed = 180;

    public KeyCode moveForwardKey;
    public KeyCode reverseKey;
    public KeyCode rightKey;
    public KeyCode leftKey;
    public KeyCode leaveCarKey;

    void Update()
    {
        bool forward = UnityEngine.Input.GetKey(moveForwardKey);
        bool reverse = UnityEngine.Input.GetKey(reverseKey);
        bool right = UnityEngine.Input.GetKey(rightKey);
        bool left = UnityEngine.Input.GetKey(leftKey);

        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        //Moving forward
        if(forward)
        {
            rigidbody.AddForce((Vector2) transform.up * (movementSpeed * Time.deltaTime));
        }

        //Moving backward
        if (reverse)
        {
            rigidbody.AddForce((Vector2) (-transform.up * (movementSpeed * Time.deltaTime)));
        }

        //Turning right
        if (right)
        {
            var rotateBy = new Vector3(0f, 0f, -rotationSpeed * Time.deltaTime * rigidbody.velocity.magnitude);
            
            transform.Rotate(rotateBy);
            rigidbody.velocity = Quaternion.Euler(rotateBy) * rigidbody.velocity;
        }

        //Turning left
        if (left)
        {
            // We want to rotate on the z-axis:
            var rotateBy = new Vector3(0f, 0f, rotationSpeed * Time.deltaTime * rigidbody.velocity.magnitude);
            // We rotate the transform:
            transform.Rotate(rotateBy);
            // And we also rotate the velocity, so that we do not continue sliding in the old direction:
            rigidbody.velocity = Quaternion.Euler(rotateBy) * rigidbody.velocity;
        }

        /*
        //Leaving a car
        bool leaveCar = Input.GetKeyDown(leaveCarKey);
        GameObject human = GameObject.Find("Human");

        if (leaveCar)
        {
            human.SetActive(true);
            GetComponent<MarcCarController>().disabled = true;
        }
        */
    }
}