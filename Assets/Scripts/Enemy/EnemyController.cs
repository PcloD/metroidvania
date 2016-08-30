using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public EnemyStats enemyStats;
    public EnemyMovement movementPattern;
    public ShotBehaviour shotBehaviour;
    public EnemyBehaviour enemyBehaviour;

    private float currhealth;
    private float nextFire;

    private Transform Head;
    private Transform BulletExitPoint;
    private Transform player;
    private float timer;

    private PointManager pointManager;

    public float CurrHealth
    {
        get { return currhealth; }
        set { currhealth = Mathf.Max(0, value); }
    }


    void Start()
    {
        timer = 0;
        nextFire = enemyStats.FireRate;
        currhealth = enemyStats.MaxHealth;
        player = GameObject.Find("Character").transform;
        if (enemyBehaviour != null)
        {
            enemyBehaviour.InitBehaviour(this);
        }
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
    }

    public void setBulletExitPoint(Transform exitPoint)
    {
        BulletExitPoint = exitPoint;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (currhealth <= 0)
        {
            Die();
        }

        if (enemyBehaviour != null)
        {
            enemyBehaviour.Behaviour(this, player);
        }
        
        if (movementPattern != null)
        {
            movementPattern.Move(transform, enemyStats.MovementSpeed, timer);
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
