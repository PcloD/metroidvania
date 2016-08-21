using UnityEngine;
using System.Collections;
using System;

[CreateAssetMenu(fileName = "BasicBehaviour", menuName = "ScriptableObjects/EnemyBehaviour/BasicBehaviour")]
public class BasicBehaviour : EnemyBehaviour
{
    public override void Behaviour(EnemyController enemy, Transform player)
    {
       
    }

    public override void InitBehaviour(EnemyController enemy)
    {
        throw new NotImplementedException();
    }
}
