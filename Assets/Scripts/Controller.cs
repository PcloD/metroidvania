using UnityEngine;
using System.Collections.Generic;

public class Controller : MonoBehaviour {

    public IMovement movementType;
    public ShotBehaviour shotBehaviour;
    public Character character;

    private BlinkSprite blinking;
    private Transform BulletExitPoint;
    private Vector3 movementVector;
    private float nextFire;
    private Collider2D collider;
    private float invulnerability = 0;
    private const int INVULNERABILITY_LAYER = 10;
    private const int PLAYER_LAYER = 8;
    private CameraUtils camBounds;
    private Transform respawn;
    private HealthManager healthUI;
    private float currhealth;

    //for laser projectiles
    private List<GameObject> beams;

    //for charging projectiles
    private float currCharging;

    // Use this for initialization
    void Start () {
        collider = GetComponent<Collider2D>();
        blinking = GetComponent<BlinkSprite>();
        camBounds = Camera.main.GetComponent<CameraUtils>();
        respawn = Camera.main.transform.FindChild("RespawnPoint");
        BulletExitPoint = transform.FindChild("BulletExitPoint");
        healthUI = GameObject.Find("HealthBar").GetComponent<HealthManager>();
        currhealth = character.MaxHealth;
        for (int i = 0; i < currhealth; i++)
            healthUI.AddHeart();

        beams = new List<GameObject>();
        currCharging = 0;
    }

    void Update()
    {
        /*
        if(currhealth <= 0)
        {
            Die();
        }*/

        if(invulnerability > 0)
        {
            invulnerability = Mathf.Max(invulnerability - Time.deltaTime, 0);
        }
        else
        {
            blinking.enabled = false;
            gameObject.layer = PLAYER_LAYER;
        }

        nextFire += Time.deltaTime;

        movementVector = movementType.getDirection(transform);

        Vector3 pos = transform.position;
        pos += (movementVector.normalized * character.MovementSpeed * Time.deltaTime);

        Vector2 camResult = camBounds.checkCamBounds(new Vector2(pos.x + collider.offset.x, pos.y + collider.offset.y), 
            new Vector2(collider.bounds.extents.x, collider.bounds.extents.y));

        //restrict controller to camera (this doesnt make MUCH sense to be here)
        if (camResult.y == 1)
        {
            pos.y = Camera.main.transform.position.y + Camera.main.orthographicSize - collider.bounds.extents.y - collider.offset.y;
        }
        else if (camResult.y == -1)
        {
            pos.y = Camera.main.transform.position.y - Camera.main.orthographicSize + collider.bounds.extents.y - collider.offset.y;
        }

        float screenRatio = Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if (camResult.x == 1)
        {
            pos.x = Camera.main.transform.position.x + widthOrtho - collider.bounds.extents.x - collider.offset.x;
        }
        else if (camResult.x == -1)
        {
            pos.x = Camera.main.transform.position.x - widthOrtho + collider.bounds.extents.x - collider.offset.x;
        }

        //Apply movement
        transform.position = pos;

        //shooting
        if (Input.GetButton("Fire1"))
        {

            if (shotBehaviour.projectile.GetComponent<IProjectile>().Type == ProjType.Projectile && 1 / character.FireRate < nextFire)
            {
                nextFire = 0; // will fire x times per second, where x is ship.FireRate
                Shoot();
            }

            if (shotBehaviour.projectile.GetComponent<IProjectile>().Type == ProjType.Laser)
            {
                ShootLaser();
            }

            if (shotBehaviour.projectile.GetComponent<IProjectile>().Type == ProjType.Chargable && 1 / character.FireRate < nextFire)
            {
                nextFire = 0; // will fire x times per second, where x is ship.FireRate
                ShootCharged(false);
            }
        }
        else
        {
            if (beams.Count > 0)
            {
                for (int i = 0; i < beams.Count; i++)
                {
                    Destroy(beams[i]);
                }
                beams = new List<GameObject>();
            }
        }

        if (Input.GetButton("Fire2"))
        {
            if (shotBehaviour.projectile.GetComponent<IProjectile>().Type == ProjType.Chargable)
            {
                Charging();
            }
        }else if(shotBehaviour.projectile.GetComponent<IProjectile>().Type == ProjType.Chargable)
        {
            if (currCharging > 0.2f)
                ShootCharged(true);
            currCharging = 0;
        }

    }

    void Charging()
    {
        currCharging += Time.deltaTime;
    }

    void Shoot()
    {
        GameObject[] shotProjectiles = new GameObject[shotBehaviour.pattern.numberOfBullets];

        for (int i = 0; i < shotBehaviour.pattern.numberOfBullets; i++)
        {
            GameObject shotProjectile = (GameObject)Instantiate(shotBehaviour.projectile, BulletExitPoint.position, Quaternion.identity);
            shotProjectiles[i] = shotProjectile;
        }

        shotBehaviour.pattern.HandlePattern(shotProjectiles);
    }

    void ShootCharged(bool chargingValue)
    {
        GameObject[] shotProjectiles = new GameObject[shotBehaviour.pattern.numberOfBullets];

        for (int i = 0; i < shotBehaviour.pattern.numberOfBullets; i++)
        {
            GameObject shotProjectile = (GameObject)Instantiate(shotBehaviour.projectile, BulletExitPoint.position, Quaternion.identity);
            shotProjectiles[i] = shotProjectile;
            shotProjectile.GetComponent<ProjectileCharge>().Initialize(chargingValue);
        }

        shotBehaviour.pattern.HandlePattern(shotProjectiles);
    }

    void ShootLaser()
    {
        if (beams.Count > 0) 
        {
            return;
        }
            
        GameObject[] shotProjectiles = new GameObject[shotBehaviour.pattern.numberOfBullets];

        for (int i = 0; i < shotBehaviour.pattern.numberOfBullets; i++)
        {
            GameObject shotProjectile = (GameObject)Instantiate(shotBehaviour.projectile, BulletExitPoint.position, Quaternion.identity);
            shotProjectiles[i] = shotProjectile;
            shotProjectile.transform.parent = BulletExitPoint;
            beams.Add(shotProjectile);
        }
       
        shotBehaviour.pattern.HandlePattern(shotProjectiles);
    }

    void Die()
    {
        Debug.Log("DED");
        RespawnPos();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Enemy"))
            TakeDamage(other.GetComponent<EnemyController>().dealContactDamage());

        if (other.tag.Equals("Environment"))
        {
            TakeDamage(1);
            RespawnPos();
        }

        if (other.tag.Equals("EnemyBullet"))
            TakeDamage(other.GetComponent<IProjectile>().Damage);

        invulnerability = character.InvulnTimer;
        gameObject.layer = INVULNERABILITY_LAYER;
        blinking.enabled = true;



        Debug.Log("Take Damage");
    }

    void RespawnPos()
    {
        transform.position = respawn.position;
    }

    void TakeDamage(float damage)
    {
        currhealth -= damage;
        healthUI.TakeDamage((int)damage);
    }

}
