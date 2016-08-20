using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public CameraMovNode nodes;
    public float scrollingSpeed = 0.1f;
    public bool altPath = false;

    private Transform[] currPath;
   // private 
    private int currNode = 1;

    // Use this for initialization
    void Start () {
        currPath = nodes.path;
    }
	
	// Update is called once per frame
	void Update () {
        if (currNode == currPath.Length)
            return;

        if(altPath && nodes.path[currNode].name.Equals("choice"))
            currPath = nodes.altPath;

        Vector3 objPosition = new Vector3(currPath[currNode].position.x, currPath[currNode].position.y, transform.position.z);
        transform.position += (objPosition - transform.position).normalized * scrollingSpeed;

        if (Vector3.Distance(objPosition, transform.position) < 0.1f )
        {
            currNode = Mathf.Min(currNode+1, currPath.Length);
        }
    }

    /*
    void OnDrawGizmos()
    {
        
        if (currNode == currPath.Length)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawCube(currPath[currNode].transform.position, new Vector3(1, 1, 1));
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position, new Vector3(.5f, .5f, .5f));
        
    }
    */



}
