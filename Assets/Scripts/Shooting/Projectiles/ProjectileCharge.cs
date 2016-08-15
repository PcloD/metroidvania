using UnityEngine;
using System.Collections;
using System;

public class ProjectileCharge: MonoBehaviour, IProjectile {


    CollisionBehaviour collBehaviour;
    public float projectileSpeed = 1f;
    public float weakDamage = .2f;
    public float chargedDamage = 2f;


    private Collider2D collider;
    private CameraUtils camBounds;
    private Vector3 movementVector;
    private float currDamage;
    private Animator animator;

    public CollisionBehaviour CollBehaviour
    {
        get { return collBehaviour; }
    }

    public Vector3 MovementVector
    {
        get
        {
            return movementVector;
        }

        set
        {
            movementVector = value;
        }
    }

    public ProjType Type
    {
        get
        {
            return ProjType.Chargable;
        }
    }

    public float Damage
    {
        get
        {
            return currDamage;
        }

        set
        {
            currDamage = value;
        }
    }

    void Start()
    {
        collBehaviour = GetComponent<CollisionBehaviour>();
        collider = GetComponent<Collider2D>();
        camBounds = Camera.main.GetComponent<CameraUtils>();
    }

    public void Initialize(bool chargedState)
    {
        animator = GetComponent<Animator>();
        animator.SetBool("charged", chargedState);
        if (chargedState)
            currDamage = chargedDamage;
        else
            currDamage = weakDamage;
    }

    void Update()
    {

        Vector3 pos = transform.position;

        pos += (movementVector.normalized * projectileSpeed * Time.deltaTime);

        Vector2 boundValues = camBounds.checkCamBounds(new Vector2(pos.x + collider.offset.x, pos.y + collider.offset.y),
            new Vector2(-collider.bounds.extents.x * 2, -collider.bounds.extents.y * 10));

        if (boundValues.x != 0 || boundValues.y != 0)
        {
            Die();
        }

        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (collBehaviour != null)
            collBehaviour.ContactBehaviour(transform.position, this);
        else
        {
            Destroy(gameObject);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
