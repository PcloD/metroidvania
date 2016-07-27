using UnityEngine;
using System.Collections;

public class ChangePath : MonoBehaviour {

    CameraFollow camFollow;

	// Use this for initialization
	void Start () {
        camFollow = Camera.main.GetComponent<CameraFollow>();
    }
	
	public void switchPath()
    {
        camFollow.altPath = true;
    }
}
