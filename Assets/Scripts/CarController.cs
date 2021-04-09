using System.Linq;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Tooltip("Movement Speed In Meters per Second")]
    public float movementSpeed = 0.1f;

    [Tooltip("Rotation Speed In Degrees per Second")]
    public float rotationSpeed = 180;

    public GameObject driver;

    public Transform exitPoint;

    private bool HasDriver => driver != null;
    private bool HasNoDriver => !HasDriver;

    void Update()
    {
        if (this.HasNoDriver)
            return;

        Drive();
    }

    public void Drive()
    {
        PlayerInput playerInput = driver.GetComponent<PlayerInput>();

        bool forward = Input.GetKey(playerInput.forwardKey);
        bool reverse = Input.GetKey(playerInput.backwardKey);
        bool right = Input.GetKey(playerInput.rightKey);
        bool left = Input.GetKey(playerInput.leftKey);
        bool exit = Input.GetKeyDown(playerInput.enterCarKey);

        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        //Moving forward
        if (forward)
        {
            rigidbody.AddForce((Vector2)transform.up * (movementSpeed * Time.deltaTime));
        }

        //Moving backward
        if (reverse)
        {
            rigidbody.AddForce((Vector2)(-transform.up * (movementSpeed * Time.deltaTime)));
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

        if (exit)
        {
            Exit();
        }
    }

    //Enter a car
    public void Enter(GameObject driverGo)
    {
        if (this.HasDriver)
            Exit();

        this.driver = driverGo;
        driverGo.SetActive(false);

        //Turn on sound
        ActivateSound(true);
    }

    //Leave a car
    void Exit()
    {
        driver.transform.position = exitPoint.position;

        driver.SetActive(true);
        driver = null;

        //Turn off sound
        ActivateSound(false);
    }

    private void ActivateSound(bool activate)
    {
        AudioSource sound = this.GetComponent<AudioSource>();
        sound.enabled = activate;
    }
}