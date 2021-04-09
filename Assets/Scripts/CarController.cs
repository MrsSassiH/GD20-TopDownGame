using System.Linq;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Tooltip("Movement Speed In Meters per Second")]
    public float movementSpeed = 0.1f;

    [Tooltip("Rotation Speed In Degrees per Second")]
    public float rotationSpeed = 180;

    public GameObject driver;

    void Update()
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
        if (exit)
        {
            Exit();
        }
    }


    //Leave a car
    public void Exit()
    {
        CarController closestCar = Resources.FindObjectsOfTypeAll<CarController>()
                .OrderBy((a) => Vector3.Distance(this.transform.position, a.transform.position))
                .First();

        Vector3 offSet = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 2, 0);
        driver.transform.position = offSet;

        driver.gameObject.SetActive(true);

        this.enabled = false;

        driver = null;

        AudioSource sound = closestCar.GetComponent<AudioSource>();
        sound.enabled = false;
    }
}