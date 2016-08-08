using UnityEngine;
using System.Collections;

public class Weaken : CollisionBehaviour
{
    public int numberOfCollisions = 1;
    private int collisionsHad = 0;

    public override void ContactBehaviour(Vector3 posOfContact, IProjectile projectile)
    {
        collisionsHad++;
        if (collisionsHad >= numberOfCollisions)
            projectile.Die();
    }

}
