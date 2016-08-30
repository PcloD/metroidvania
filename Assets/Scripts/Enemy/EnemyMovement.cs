using UnityEngine;
using System.Collections;

public abstract class EnemyMovement : ScriptableObject
{
   public abstract void Move(Transform enemy, float speed, float timer);
}
