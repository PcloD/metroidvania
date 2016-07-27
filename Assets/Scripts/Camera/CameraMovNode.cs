using UnityEngine;
using System.Collections.Generic;

[ExecuteInEditMode]
public class CameraMovNode : MonoBehaviour {

    public Transform[] path;
    public Transform[] altPath;

    void Update()
    {
        Transform[] childs = GetComponentsInChildren<Transform>();
        List<Transform> pathList = new List<Transform>();
        List<Transform> altPathList = new List<Transform>();

        for(int i = 0; i < childs.Length; i++)
        {

            if (!childs[i].name.Contains("b"))
            {
                pathList.Add(childs[i]);
            }

            if (!childs[i].name.Contains("a"))
            {
                altPathList.Add(childs[i]);
            }
        }
        path = pathList.ToArray();
        altPath = altPathList.ToArray();
        
    }

}
