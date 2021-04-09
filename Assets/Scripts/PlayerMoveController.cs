using System.Linq;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [Tooltip("Movement Speed In Meters per Second")]
    public float movementSpeed = 0.1f;
    public float rotationSpeed = 180;

    public PlayerInput playerInput;


    // Start is called before the first frame update
    void Start()
    {
        // Use transform.position, IF you want to set the position to a certain value
        // For example: if you want the player to teleport
        // Or to set a new Enemy's Position to its Spawn Point
        transform.position = Vector3.zero;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        bool forward = Input.GetKey(playerInput.forwardKey);
        bool backward = Input.GetKey(playerInput.backwardKey);
        bool left = Input.GetKey(playerInput.leftKey);
        bool right = Input.GetKey(playerInput.rightKey);
        bool enterCar = Input.GetKeyDown(playerInput.enterCarKey);

        // If the Forward Key is Pressed, MOVE the TRANSFORM in the UP-direction
        // scaled by the MOVEMENT SPEED and the DELTA TIME (the time that has passed)
        if (forward)
        {
            // Use transform.Translate, if you want to move a transform
            transform.Translate(Vector3.up * (movementSpeed * Time.deltaTime));
        }
        if (backward)
        {
            transform.Translate(Vector3.down * (movementSpeed * Time.deltaTime));
        }
        if (left)
        {
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        }
        if (right)
        {
            transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
        }

        if (enterCar)
        {
            CarController closestCar = GetClosesCar();

            // Get the distance between the car's position and this' (the Human's) position
            float distance = Vector3.Distance(closestCar.transform.position, this.transform.position);

            // Only if the distance is smaller than the threshold...
            if (distance < 3f)
            {
                closestCar.Enter(this.gameObject);
            }

        }
    }

    CarController GetClosesCar()
    {
        return Resources.FindObjectsOfTypeAll<CarController>()
             .OrderBy((car) => Vector3.Distance(this.transform.position, car.transform.position))
             .First();
    }

}
