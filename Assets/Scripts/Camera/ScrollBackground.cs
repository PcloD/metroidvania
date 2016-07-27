using UnityEngine;
using System.Collections;

public class ScrollBackground : MonoBehaviour {

    public float scrollingSpeed;
    public bool autoScrolling = true;

    Material material;

	// Use this for initialization
	void Start () {
        material = GetComponent<MeshRenderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 offset = material.mainTextureOffset;

        if(autoScrolling)
            offset.x += Time.deltaTime * scrollingSpeed;
        else
        {
            offset.x = transform.position.x / transform.localScale.x * scrollingSpeed;
           // offset.y = transform.position.y / transform.localScale.y * scrollingSpeed;
        }
        
        material.mainTextureOffset = offset;

    }
}
