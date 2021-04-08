using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [Tooltip("Movement Speed In Meters per Second")]
    public float movementSpeed = 0.1f;

    public KeyCode forwardKey;
    public KeyCode backwardKey;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode enterCarKey;

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
        bool forward = Input.GetKey(forwardKey);
        bool backward = Input.GetKey(backwardKey);
        bool left = Input.GetKey(leftKey);
        bool right = Input.GetKey(rightKey);

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
            transform.Translate(Vector3.left * (movementSpeed * Time.deltaTime));
        }
        if (right)
        {
            transform.Translate(Vector3.right * (movementSpeed * Time.deltaTime));
        }


        //Entering a car
        bool enterCar = Input.GetKeyDown(enterCarKey);
        GameObject bCar = GameObject.Find("BlueCar");
        GameObject rCar = GameObject.Find("RedCar");

        float distanceB = Vector3.Distance(this.transform.position, bCar.transform.position);
        float distanceR = Vector3.Distance(this.transform.position, rCar.transform.position);
        //Enter Blue Car
        if (enterCar && (distanceB < 3f))
        {
            MarcCarController marcCarController = bCar.GetComponent<MarcCarController>();
            marcCarController.enabled = true;
            marcCarController.driver = this.gameObject;

            this.gameObject.SetActive(false);
        }
        //Enter Red Car
        if (enterCar && (distanceR < 3f))
        {
            MarcCarController marcCarController = rCar.GetComponent<MarcCarController>();
            marcCarController.enabled = true;
            marcCarController.driver = this.gameObject;

            this.gameObject.SetActive(false);
        }
    }
}
