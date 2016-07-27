using UnityEngine;
using System.Collections;

public abstract class IMovement : ScriptableObject
{
    public abstract Vector3 getDirection(Transform shipPos);
}
