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
            GameObject bCar = GameObject.Find("BlueCar");

            /*
            CarController closestCar = Resources.FindObjectsOfTypeAll<CarController>()
                            .OrderBy((a) => Vector3.Distance(this.transform.position, a.transform.position))
                            .First();
            */

            float distance = Vector3.Distance(this.transform.position, bCar.transform.position);

            CarController carController = bCar.GetComponent<CarController>();
            if (distance < 3f)
            {

                if (carController.driver == null)
                {
                    carController.enabled = true;
                    carController.driver = this.gameObject;

                    this.gameObject.SetActive(false);

                    AudioSource sound = bCar.GetComponent<AudioSource>();
                    sound.enabled = true;
                }
                else
                {
                    /*If there is a driver
                     * - Remove driver from carController
                     * - Set the driver active
                     * - Add the new Diver to CarController
                     */
                  
                    Vector3 offSet = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 2, 0);
                    carController.driver.SetActive(true);
                    carController.driver.transform.position = offSet;

                    carController.driver = null;

                    carController.enabled = true;

                    AudioSource sound = bCar.GetComponent<AudioSource>();
                    sound.enabled = true;
                }
            }
        }

        //GameObject rCar = GameObject.Find("RedCar");

        //float distance = Vector3.Distance(this.transform.position, car.transform.position);
        //float distanceR = Vector3.Distance(this.transform.position, rCar.transform.position);

        /*
        //Enter Red Car
        if (enterCar && (distanceR < 3f))
        {
            CarController marcCarController = rCar.GetComponent<CarController>();
            marcCarController.enabled = true;
            marcCarController.driver = this.gameObject;

            this.gameObject.SetActive(false);

            AudioSource sound = rCar.GetComponent<AudioSource>();
            sound.enabled = true;

        }
        */
    }
}
