using UnityEngine;
using System.Collections;

public abstract class CollisionBehaviour : MonoBehaviour
{
   public abstract void ContactBehaviour(Vector3 posOfContact, Projectile projectile);
}
