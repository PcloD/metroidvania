using UnityEngine;
using System.Collections;

public abstract class Pattern : ScriptableObject
{
    public int numberOfBullets = 1;
    public abstract void HandlePattern(GameObject[] shotProjectiles);
}
