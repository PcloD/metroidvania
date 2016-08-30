using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraMovNode))]
public class CameraMovNodeEditor : Editor
{

    void OnEnable()
    {
        SceneView.onSceneGUIDelegate -= OnScene;
        SceneView.onSceneGUIDelegate += OnScene;
    }

    void OnScene(SceneView sceneview)
    {
        CameraMovNode t = target as CameraMovNode;

        EditorGUI.BeginChangeCheck();

        for (int i = 1; i < t.path.Length; i++)
        {
            if (t.path[i] != null)
                Handles.DrawLine(t.path[i-1].transform.position, t.path[i].transform.position);
        }

        for (int i = 1; i < t.altPath.Length; i++)
        {
            if (t.altPath[i] != null)
                Handles.DrawLine(t.altPath[i - 1].transform.position, t.altPath[i].transform.position);
        }

    }
}
