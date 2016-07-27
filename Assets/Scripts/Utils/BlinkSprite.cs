using UnityEngine;
using System.Collections;

public class BlinkSprite : MonoBehaviour {

    public float blinkSpeed = 10;
    public bool smoothTransiction = false;

    SpriteRenderer rend;
    float timer;

    void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        Color newColor = rend.material.GetColor("_Color");

        if(smoothTransiction)
            newColor.a = Mathf.PingPong(timer * blinkSpeed, 1f);
        else
        {
            if (timer > 1 / blinkSpeed)
            {
                if (newColor.a == 0)
                    newColor.a = 1f;
                else
                    newColor.a = 0f;

                timer = 0f;
            }
        }

        rend.material.SetColor("_Color", newColor);
    }

    void OnDisable()
    {
        Color newColor = rend.material.GetColor("_Color");

        newColor.a = 0f;

        rend.material.SetColor("_Color", newColor);
    }


}
