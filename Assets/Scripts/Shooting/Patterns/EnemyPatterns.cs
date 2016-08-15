using UnityEngine;
using System.Collections;

public abstract class EnemyPatterns : Pattern
{
    public abstract void HandlePattern(GameObject[] shotProjectiles, Vector3 playerPos);
}
