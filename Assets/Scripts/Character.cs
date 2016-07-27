using UnityEngine;
using System.Collections;

public class Character : ScriptableObject
{

    [SerializeField]
    private float maxHealth = 5;
    [SerializeField]
    private float movementSpeed = 10;
    [SerializeField]
    private float fireRate = 5;
    [SerializeField]
    private float invulnTimer = 1f;

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

    public float InvulnTimer
    {
        get { return invulnTimer; }
        set { invulnTimer = value; }
    }

}
