using UnityEngine;
using System.Collections;
using System;

[CreateAssetMenu(fileName = "StraightMovement", menuName = "ScriptableObjects/EnemyMovement/StraightMovement")]
public class StraightMovement : EnemyMovement
{
    public Vector3 direction;

    public override void Move(Transform enemy, float speed, float timer)
    {
        enemy.position += direction * speed * Time.deltaTime;
    }

}
