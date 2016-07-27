using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

    public float timeToDie = 1f;

    void Start()
    {
        Destroy(gameObject, timeToDie);
    }
}
