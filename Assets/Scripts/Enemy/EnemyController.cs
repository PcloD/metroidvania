using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public EnemyStats enemyStats;
    private float currhealth;

    public float CurrHealth
    {
        get { return currhealth; }
        set { currhealth = Mathf.Max(0, value); }
    }


    void Start()
    {
        currhealth = enemyStats.MaxHealth;
    }

    void Update()
    {
        if (currhealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(enemyStats.deathExplosion, this.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


    public float dealContactDamage()
    {
        return enemyStats.TouchDamage;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.tag.Equals("Player"))
            currhealth -= other.GetComponent<Projectile>().damageDealt;
    }
}
