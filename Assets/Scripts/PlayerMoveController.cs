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
        bool forward = Input.GetKey(playerInput.forwardKey);
        bool backward = Input.GetKey(playerInput.backwardKey);
        bool left = Input.GetKey(playerInput.leftKey);
        bool right = Input.GetKey(playerInput.rightKey);

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

        //Entering a car
        bool enterCar = Input.GetKeyDown(playerInput.enterCarKey);
        if (enterCar)
        {
            Enter();
        }
    }


    //Entering a car
    public void Enter()
    {
        CarController closestCar = Resources.FindObjectsOfTypeAll<CarController>()
                .OrderBy((a) => Vector3.Distance(this.transform.position, a.transform.position))
                .First();

        float distance = Vector3.Distance(this.transform.position, closestCar.transform.position);

        if (distance < 3f)
        {
            if (closestCar.driver == null)
            {
                closestCar.enabled = true;
                closestCar.driver = this.gameObject;

                this.gameObject.SetActive(false);

                AudioSource sound = closestCar.GetComponent<AudioSource>();
                sound.enabled = true;
            }
            else
            {
                closestCar.Exit();

                closestCar.enabled = true;
                closestCar.driver = this.gameObject;

                this.gameObject.SetActive(false);

                AudioSource sound = closestCar.GetComponent<AudioSource>();
                sound.enabled = true;
            }
        }
    }


}
