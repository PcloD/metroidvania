using UnityEngine;
using System.Collections;
using System;

public class Dissapear : CollisionBehaviour
{
    public override void ContactBehaviour(Vector3 posOfContact, Projectile projectile)
    {
        projectile.Die();
    }
}
