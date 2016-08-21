using UnityEngine;
using System.Collections;
using System;

[CreateAssetMenu(fileName = "TurretBehaviour", menuName = "ScriptableObjects/EnemyBehaviour/TurretBehaviour")]
public class TurretBehaviour : EnemyBehaviour
{
    Transform head;

    public override void Behaviour(EnemyController enemy, Transform player)
    {
        var dir = player.position - head.position;
        float atan2 = Mathf.Atan2(dir.y, dir.x);

        head.rotation = Quaternion.Lerp(head.rotation, Quaternion.Euler(0f, 0f, 180 + -atan2 * Mathf.Rad2Deg), 40 * Time.deltaTime);
    }

    public override void InitBehaviour(EnemyController enemy)
    {
        enemy.setBulletExitPoint(enemy.transform.FindChild("Head/BulletExitPoint"));
        head = enemy.transform.FindChild("Head");
    }
}
