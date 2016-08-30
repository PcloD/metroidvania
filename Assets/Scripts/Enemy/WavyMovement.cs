using UnityEngine;
using System.Collections;
using System;

[CreateAssetMenu(fileName = "WavyMovement", menuName = "ScriptableObjects/EnemyMovement/WavyMovement")]
public class WavyMovement : EnemyMovement
{
    public Vector3 direction;
    public float amplitude;
    public float frequency;

    public override void Move(Transform enemy, float speed, float timer)
    {
        enemy.position += new Vector3(direction.x * speed * Time.deltaTime, Mathf.Sin(timer * frequency) * amplitude, 0);

    }

}
