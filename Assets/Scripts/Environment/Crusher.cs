using UnityEngine;
using System.Collections;

public class Crusher : MonoBehaviour {

    public float speed = 1;

    private Animator animator;

	// Use this for initialization
	void Start () {

        animator = GetComponent<Animator>();
        animator.SetFloat("Speed", speed);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
