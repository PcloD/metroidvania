using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "LinePattern", menuName = "ScriptableObjects/Pattern/LinePattern")]
public class LinePattern : Pattern
{
    public Vector3 directionToShoot;


    public override void HandlePattern(GameObject[] shotProjectiles)
    {
        shotProjectiles[0].GetComponent<Projectile>().movementVector = directionToShoot;
    }

}
