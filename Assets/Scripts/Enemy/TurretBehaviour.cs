using UnityEngine;
using System.Collections;
using System;

public class TurretBehaviour : EnemyBehaviour
{
    Transform head;

    public override void Behaviour(EnemyController enemy, Transform player)
    {
        var dir = player.position - head.position;
        float atan2 = (Mathf.Atan2(dir.y, dir.x) *-1 *Mathf.Rad2Deg) + 180 ;
        if (atan2 > 180)
            atan2 = 360 - atan2; 
        if(atan2 < 60)
            head.rotation = Quaternion.Lerp(head.rotation, Quaternion.Euler(0f, 0f, atan2), 40 * Time.deltaTime);
    }

    public override void InitBehaviour(EnemyController enemy)
    {
        enemy.setBulletExitPoint(enemy.transform.FindChild("Head/BulletExitPoint"));
        head = enemy.transform.FindChild("Head");
    }
}
