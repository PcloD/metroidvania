using UnityEngine;
using System.Collections;

public class Destructable : MonoBehaviour {

    public int collisions = 1;
    private int collisionsHad = 0;

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("PlayerBullet"))
        {
            collisionsHad++;
            if (collisionsHad >= collisions)
            {
                if (GetComponent<ChangePath>() != null)
                    GetComponent<ChangePath>().switchPath();
                Destroy(gameObject);
            }
        }
    }


}
