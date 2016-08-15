using UnityEngine;
using System.Collections;
using System;

[CreateAssetMenu(fileName = "AtPlayer", menuName = "ScriptableObjects/Pattern/EnemyPatterns/AtPlayer")]
public class AtPlayer : EnemyPatterns
{
    public override void HandlePattern(GameObject[] shotProjectiles)
    {
        shotProjectiles[0].GetComponent<IProjectile>().MovementVector = Vector3.left;
    }

    public override void HandlePattern(GameObject[] shotProjectiles, Vector3 playerPos)
    {
        shotProjectiles[0].GetComponent<IProjectile>().MovementVector = playerPos - shotProjectiles[0].transform.position;
    }
}
