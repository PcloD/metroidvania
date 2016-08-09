using UnityEngine;
using System.Collections;
using System;

public class ProjectileTracker : MonoBehaviour, IProjectile {


    CollisionBehaviour collBehaviour;
    public float projectileSpeed = 1f;
    public float damageDealt = 1f;
    public float trackingRange = 1f;
    private Collider2D collider;
    private CameraUtils camBounds;
    private Transform target;
    private Vector3 movementVector;

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
            return ProjType.Projectile;
        }
    }

    public float Damage
    {
        get
        {
            return damageDealt;
        }

        set
        {
            damageDealt = value;
        }
    }

    void Start()
    {
        collBehaviour = GetComponent<CollisionBehaviour>();
        collider = GetComponent<Collider2D>();
        camBounds = Camera.main.GetComponent<CameraUtils>();
        target = null;
    }

    void Update()
    {
        Vector3 pos = transform.position;

        if (target == null)
        {
            Collider2D enemyNearby = Physics2D.OverlapCircle(transform.position, trackingRange, 1 << LayerMask.NameToLayer("Enemy"));
            if (enemyNearby != null)
            {
                target = enemyNearby.transform;
            }
        }

        if (target == null)
            pos += (movementVector.normalized * projectileSpeed * Time.deltaTime);
        else
        {
            pos += ((target.position - transform.position).normalized * projectileSpeed * Time.deltaTime);
        }

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

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, trackingRange);
    }
}
