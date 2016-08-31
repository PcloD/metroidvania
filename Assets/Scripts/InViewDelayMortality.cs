using UnityEngine;
using System.Collections;

public class InViewDelayMortality : MonoBehaviour {

    private int originalLayer;
    private Collider2D collider;
    private CameraUtils camUtil;

    // Use this for initialization
    void Start () {
        originalLayer = gameObject.layer;
        gameObject.layer = 10;
        collider = GetComponent<Collider2D>();
        camUtil = Camera.main.GetComponent<CameraUtils>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 boundValuesForCollider = camUtil.checkCamBounds(new Vector2(transform.position.x + collider.offset.x, transform.position.y + collider.offset.y),
            new Vector2(collider.bounds.extents.x, -collider.bounds.extents.y));

        if (boundValuesForCollider.x == 0 && boundValuesForCollider.y == 0)
        {
            gameObject.layer = originalLayer;
        }

    }
}
