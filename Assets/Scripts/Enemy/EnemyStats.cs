using UnityEngine;
using System.Collections;

public class EnemyStats : ScriptableObject
{

    [SerializeField]
    private float maxHealth = 1;
    [SerializeField]
    private float movementSpeed = 15;
    [SerializeField]
    private float fireRate = 5;
    [SerializeField]
    private float touchDamage = 1;
    public GameObject deathExplosion;

    public float MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = Mathf.Max(0, value); }
    }

    public float MovementSpeed
    {
        get { return movementSpeed; }
        set { movementSpeed = value; }
    }

    public float FireRate
    {
        get { return fireRate; }
        set { fireRate = value; }
    }

    public float TouchDamage
    {
        get { return touchDamage; }
        set { touchDamage = value; }
    }

}
