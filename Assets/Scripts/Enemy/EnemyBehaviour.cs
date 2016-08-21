using UnityEngine;
using System.Collections;

public abstract class EnemyBehaviour : ScriptableObject
{
    public abstract void InitBehaviour(EnemyController enemy);
    public abstract void Behaviour(EnemyController enemy, Transform player);
}
