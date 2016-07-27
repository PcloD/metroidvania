using UnityEngine;
using System.Collections;

public class CameraUtils : MonoBehaviour {
    CameraBoundsChecker camBounds;

    void Start()
    {
        camBounds = new CameraBoundsChecker();
    }

    public Vector2 checkCamBounds(Vector2 posToCheck, Vector2 size)
    {
       return camBounds.isInsideCameraBounds(posToCheck, size);
    }

}
