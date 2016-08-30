using UnityEngine;
using System.Collections;

public class InViewStart : MonoBehaviour {

    public bool inCamera = false;
    private EnemyController enemyController;
    private Animator animator;
    private CameraUtils camUtil;
    private Collider2D collider;

    // Use this for initialization
    void Start () {
        enemyController = GetComponent<EnemyController>();
        camUtil = Camera.main.GetComponent<CameraUtils>();
        collider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (inCamera)
        {
            if(enemyController != null)
                enemyController.enabled = true;

            if (animator != null)
                animator.enabled = true;
        }
        else
        {
            Vector2 boundValues = camUtil.checkCamBounds(new Vector2(transform.position.x - collider.offset.x, transform.position.y - collider.offset.y),
                new Vector2(-collider.bounds.extents.x, -collider.bounds.extents.y));

            inCamera = boundValues.x == 0 && boundValues.y == 0;

        }

    }


}
