using UnityEngine;
using System.Collections;

public class LaserProj : MonoBehaviour, IProjectile
{

    CollisionBehaviour collBehaviour;
    public float speed = 1f;
    public float range = 4f;
    public float damageDealt = 1f;


    private Collider2D collider;
    private CameraUtils camBounds;
    private Transform target;
    private Vector3 movementVector;
    private LineRenderer line;
    private Vector3 lastPosProgression;

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

    public void Die()
    {
       
    }

    void Start()
    {
        collBehaviour = GetComponent<CollisionBehaviour>();
        collider = GetComponent<Collider2D>();
        camBounds = Camera.main.GetComponent<CameraUtils>();
        line = GetComponent<LineRenderer>();
        lastPosProgression = transform.position;
        line.SetPosition(0, lastPosProgression);
    }

    void Update()
    {
        lastPosProgression += new Vector3(lastPosProgression.x, lastPosProgression.y + speed * Time.deltaTime, lastPosProgression.z);
        line.SetPosition(1, lastPosProgression);

        Vector3 pos = transform.position;

        Vector2 boundValues = camBounds.checkCamBounds(new Vector2(pos.x + collider.offset.x, pos.y + collider.offset.y),
            new Vector2(-collider.bounds.extents.x * 2, -collider.bounds.extents.y * 10));

        if (boundValues.x != 0 || boundValues.y != 0)
        {
            
        }

    }

}
