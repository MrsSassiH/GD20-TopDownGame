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

    public GameObject driver;

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

        //Leave a car
        bool exit = Input.GetKeyDown(leaveCarKey);
        GameObject bCar = GameObject.Find("BlueCar");
        GameObject rCar = GameObject.Find("RedCar");
        //Leave Blue Car
        if (exit)
        {
            driver.transform.position = this.transform.position;

            driver.gameObject.SetActive(true);

            MarcCarController marcCarController = bCar.GetComponent<MarcCarController>();
            marcCarController.enabled = false;

            AudioSource sound = bCar.GetComponent<AudioSource>();
            sound.enabled = false;
        }
        //Leave Red Car
        if (exit)
        {
            driver.transform.position = this.transform.position;

            driver.gameObject.SetActive(true);

            MarcCarController marcCarController = rCar.GetComponent<MarcCarController>();
            marcCarController.enabled = false;

            AudioSource sound = rCar.GetComponent<AudioSource>();
            sound.enabled = false;
        }
    }
}