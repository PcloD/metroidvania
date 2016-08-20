using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {

    public DoorOpen door;
    public ChangePath change;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("PlayerBullet"))
        {
            door.enabled = true;
            change.switchPath();
        }
    }
}
