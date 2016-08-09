using UnityEngine;
using System.Collections;

public class LaserProj : MonoBehaviour, IProjectile
{

    CollisionBehaviour collBehaviour;
    public Vector3 ShootingPos;
    public float speed = 1f;
    public float range = 4f;
    public float damageDealt = 1f;

    private Collider2D collider;
    private CameraUtils camBounds;
    private Transform target;
    private Vector3 movementVector;
    public LineRenderer line;
    private float currentLineLength;
    private bool extended;


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
            return ProjType.Laser;
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
        extended = false;
        collBehaviour = GetComponent<CollisionBehaviour>();
        collider = GetComponent<Collider2D>();
        camBounds = Camera.main.GetComponent<CameraUtils>();
        line = GetComponent<LineRenderer>();
        currentLineLength = 0;
        ShootingPos = transform.position;
        line.SetPosition(0, ShootingPos);
        line.SetPosition(1, ShootingPos);
    }

    void Update()
    {
        line.SetPosition(0, ShootingPos);

        if (extended)
            line.SetPosition(1, ShootingPos + movementVector.normalized * range);
        else {
            currentLineLength += speed * Time.deltaTime;
            line.SetPosition(1, ShootingPos + movementVector.normalized * currentLineLength);
        }

        if (Vector3.Distance(ShootingPos, ShootingPos + movementVector.normalized * currentLineLength) >= range)
            extended = true;
    }

}
