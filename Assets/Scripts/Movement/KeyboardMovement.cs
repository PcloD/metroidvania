using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "KeyboardMovement", menuName = "ScriptableObjects/KeyboardMovement")]
public class KeyboardMovement : IMovement
{

    public override Vector3 getDirection(Transform shipPos)
    {
        Vector3 movementVector = new Vector3(0, 0, 0);
        if ((Input.GetButton("Horizontal") || Input.GetButton("Vertical")))
        {
            movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        return movementVector;
    }

}
