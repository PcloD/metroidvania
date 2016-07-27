using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    CollisionBehaviour collBehaviour;
    public Vector3 movementVector;
    public float projectileSpeed = 1f;
    public float damageDealt = 1f;
    private Collider2D collider;
    private CameraUtils camBounds;

    public CollisionBehaviour CollBehaviour
    {
        get { return collBehaviour; }
    }

    void Start()
    {
        collBehaviour = GetComponent<CollisionBehaviour>();
        collider = GetComponent<Collider2D>();
        camBounds = Camera.main.GetComponent<CameraUtils>();
    }

    void Update()
    {
        Vector3 pos = transform.position;

        pos += (movementVector.normalized * projectileSpeed * Time.deltaTime);

        Vector2 boundValues = camBounds.checkCamBounds(new Vector2(pos.x + collider.offset.x, pos.y + collider.offset.y),
            new Vector2(-collider.bounds.extents.x *2, -collider.bounds.extents.y*10));

        if (boundValues.x != 0 || boundValues.y != 0)
        {
            Die();
        }

        transform.position = pos;
    }

        void OnTriggerEnter2D(Collider2D other)
    {
        if(collBehaviour != null)
            collBehaviour.ContactBehaviour(transform.position, this);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
