using UnityEngine;

public class CarController : MonoBehaviour
{
    [Tooltip("Rotation Speed In Degrees per Second")]
    public float rotationSpeed = 80;

    public KeyCode moveForwardKey;
    public KeyCode brakeKey;
    public KeyCode rotateLeftKey;
    public KeyCode rotateRightKey;

    // Update is called once per frame
    void Update()
    {
        //Accelerates
        bool forward = Input.GetKey(moveForwardKey);
        if(forward)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up);
        }

        //Brakes
        bool slowDown = Input.GetKey(brakeKey);
        if(slowDown)
        {
            GetComponent<Rigidbody2D>().AddForce(-transform.up);
        }

        // Rotates Right
        bool rotateRight = UnityEngine.Input.GetKey(rotateRightKey);
        if (rotateRight)
        {
            transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
        }

        // Rotates Left
        bool rotateLeft = UnityEngine.Input.GetKey(rotateLeftKey);
        if (rotateLeft)
        {
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }
}
