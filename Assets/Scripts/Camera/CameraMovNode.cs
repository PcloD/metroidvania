using UnityEngine;
using System.Collections.Generic;

[ExecuteInEditMode]
public class CameraMovNode : MonoBehaviour {

    public Transform[] path;
    public Transform[] altPath;

    void Update()
    {
        List<Transform> pathList = new List<Transform>();
        List<Transform> altPathList = new List<Transform>();

        foreach (Transform child in transform)
        {

            if (!child.name.Contains("b"))
            {
                pathList.Add(child);
            }

            if (!child.name.Contains("a"))
            {
                altPathList.Add(child);
            }
        }
        path = pathList.ToArray();
        altPath = altPathList.ToArray();
        
    }

}
