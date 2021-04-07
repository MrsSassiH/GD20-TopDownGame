using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /* 10 * 0.01f = 1/100 -> 10 * (1/100) -> 10/100 -> 0.1
     * 0.5 -> 1/2
     * 0.25 -> 1/4
     * 0.1 -> 1/10
     * 0.01 -> 1/100
     */

    public float movementSpeed = 0.1f; 

    // Update is called once per frame
    void Update()
    {
       /*We assignthe Righthand-Side
        * - when is the Result of the GetKey-Method
        * - which is of type 'bool'
        * To the Lefthand-Side
        * - which is a var named forward
        *- which is of type 'bool'
        */
        bool forward = UnityEngine.Input.GetKey(KeyCode.W);
        
        if(forward)
        {
           /*Transform points to this GameObject's Transform-Component
            * Transform Moves the Transform in a certain direction
            * Vector3.up is always X: 0, Y: 1, Z: 0
            */
            transform.Translate(Vector3.up * (movementSpeed * Time.deltaTime));

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
