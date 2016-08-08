using UnityEngine;
using System.Collections;

public enum ProjType
{
    Projectile, Laser, Chargable
}

public interface IProjectile {

    Vector3 MovementVector
    {
        get;
        set;
    }

    float Damage
    {
        get;
        set;
    }

    void Die();
}
