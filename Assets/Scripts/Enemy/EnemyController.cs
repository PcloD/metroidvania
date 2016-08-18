using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public EnemyStats enemyStats;
    public EnemyMovement movementPattern;
    public ShotBehaviour shotBehaviour;

    private float currhealth;
    private float nextFire;

    private Transform BulletExitPoint;
    private Transform player;

    private PointManager pointManager;

    public float CurrHealth
    {
        get { return currhealth; }
        set { currhealth = Mathf.Max(0, value); }
    }


    void Start()
    {
        nextFire = enemyStats.FireRate;
        BulletExitPoint = transform.FindChild("BulletExitPoint");
        currhealth = enemyStats.MaxHealth;
        player = GameObject.Find("Character").transform;
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
    }

    void Update()
    {
        if (currhealth <= 0)
        {
            Die();
        }

        if(movementPattern != null)
        {
            movementPattern.Move(transform, enemyStats.MovementSpeed);
        }

        nextFire += Time.deltaTime;

        if  (shotBehaviour != null && 1 / enemyStats.FireRate < nextFire)
        {
            nextFire = 0; // will fire x times per second, where x is ship.FireRate
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject[] shotProjectiles = new GameObject[shotBehaviour.pattern.numberOfBullets];

        for (int i = 0; i < shotBehaviour.pattern.numberOfBullets; i++)
        {
            GameObject shotProjectile = (GameObject)Instantiate(shotBehaviour.projectile, BulletExitPoint.position, Quaternion.identity);
            shotProjectiles[i] = shotProjectile;
            shotProjectile.tag = "EnemyBullet";
            shotProjectile.layer = 9;
        }
        
        ((EnemyPatterns)(shotBehaviour.pattern)).HandlePattern(shotProjectiles, player.position);
    }

    void Die()
    {
        Instantiate(enemyStats.deathExplosion, this.transform.position, Quaternion.identity);
        Destroy(gameObject);
        pointManager.CurrentPoints += enemyStats.Points;
        pointManager.killRecently();
    }


    public float dealContactDamage()
    {
        return enemyStats.TouchDamage;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("PlayerBullet"))
            currhealth -= other.GetComponent<IProjectile>().Damage;
    }
}
