using UnityEngine;
using System.Collections;

public class Explode : CollisionBehaviour
{
    public GameObject explosion;

    public override void ContactBehaviour(Vector3 posOfContact, IProjectile projectile)
    {
        projectile.Die();
    }
}
