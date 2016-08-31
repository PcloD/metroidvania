using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour {

    public Vector2 minMaxExplosionSize;

	// Use this for initialization
	void Start () {
        Vector3 rotation = transform.eulerAngles;
        rotation.z = Random.Range(0, 360f);
        transform.eulerAngles = rotation;

        float xy = Random.Range(1f, 5f);
        Vector3 size = new Vector3(xy, xy, 1);
        transform.localScale = size;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
