using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
            transform.Translate(Vector3.up);
        }

    }



}
