using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public GameObject heart;
    List<GameObject> heartsAdded;
    float offsetHeart;
    int lastInactiveHeart;

    void Start()
    {
        lastInactiveHeart = -1;
        offsetHeart = heart.GetComponent<RectTransform>().rect.width/4;
        heartsAdded = new List<GameObject>();
    }

    public void AddHeart() {

        if (heartsAdded.Count == 0 || heartsAdded[heartsAdded.Count - 1].activeSelf)
        {
            GameObject heartInstanced = (GameObject)Instantiate(heart, transform.position + Vector3.right * (heartsAdded.Count * offsetHeart), Quaternion.identity);
            heartInstanced.transform.SetParent(transform);
            heartInstanced.transform.position = transform.position + Vector3.right * (heartsAdded.Count * offsetHeart);
            heartsAdded.Add(heartInstanced);
            lastInactiveHeart++;
        }
        else
        {
            heartsAdded[lastInactiveHeart].SetActive(false);
        }
    }

    public void RemoveHeart() {

    }

    public void TakeDamage(int damage)
    {
        int i;
        for (i = lastInactiveHeart; i > lastInactiveHeart - damage; i--)
        {
            heartsAdded[i].SetActive(false);   
        }
        lastInactiveHeart = i;
    }

}
