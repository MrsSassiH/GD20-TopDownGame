using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationController : MonoBehaviour
{
    public float movementSpeed = 4f;
    public float rotationSpeed = 50f;

    // Update is called once per frame
    void Update()
    {
        bool forward = UnityEngine.Input.GetKey(KeyCode.W);
        bool down = UnityEngine.Input.GetKey(KeyCode.S);
        bool left = UnityEngine.Input.GetKey(KeyCode.A);
        bool right = UnityEngine.Input.GetKey(KeyCode.D);

        //Moing forward
        if (forward)
        {
            transform.Translate(Vector3.up * (movementSpeed * Time.deltaTime));
        }

        //Moving down
        if (down)
        {
            transform.Translate(Vector3.down * (movementSpeed * Time.deltaTime));
        }

        //Rotating left
        if(left)
        {
            transform.Rotate(0, 0, 1 * (rotationSpeed * Time.deltaTime));
        }

        //Rotating right
        if (right)
        {
            transform.Rotate(0, 0, -1 * (rotationSpeed * Time.deltaTime));
        }

    }


    // Start is called before the first frame update
    void Start()
    {

    }
}
