using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour {

    public Animator[] Doors;
    public float startDelay;
    public float delayPerDoor;

    private float timer;
    private int door;

	// Use this for initialization
	void Start () {
        timer = 0;
        door = 0;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer >= startDelay && !Doors[0].GetBool("CanOpen"))
        {
            Doors[0].Play("Open");
            door = 1;
            timer = 0;
            Debug.Log(Doors[0].name);
        }

        if (timer >= delayPerDoor)
        {
            timer = 0;
            if (door >= Doors.Length)
            {
                enabled = false;
                return;
            }
            Doors[door].Play("Open");
            door++;
        }

	}


}
