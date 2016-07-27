using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "ShotBehaviour", menuName = "ScriptableObjects/ShotBehaviour")]
public class ShotBehaviour : ScriptableObject
{
    public GameObject projectile;
    public Pattern pattern;
}
