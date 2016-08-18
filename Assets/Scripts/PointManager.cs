using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointManager : MonoBehaviour {

    public float timeBetweenStrings = 3f;
    public float killsToNextBonus = 6;

    private float currentPoints;
    private float currBonus;
    private float timer;
    private float currkills;

    private Image TimerUI;
    private Text pointsUI;
    private Text multiplierUI;

    public float CurrentPoints
    {
        get
        {
            return currentPoints;
        }

        set
        {
            currentPoints = value * currBonus;
            pointsUI.text = currentPoints.ToString();
        }
    }

    void Start()
    {
        timer = 0;
        currBonus = 1;
        TimerUI = GameObject.Find("Bonus Timer").GetComponent<Image>();
        pointsUI = GameObject.Find("Points").GetComponent<Text>();
        multiplierUI = GameObject.Find("Multiplier").GetComponent<Text>();
    }

    void Update()
    {
        TimerUI.fillAmount = timer/ timeBetweenStrings;

        if(currkills > 0)
            timer += Time.deltaTime;

        if (timer >= timeBetweenStrings)
        {
            timer = 0;
            currBonus = 1;
            currkills = 0;
            multiplierUI.text = "x1";
        }
    }


    public void killRecently()
    {
        currkills++;
        if(currkills % killsToNextBonus == 0)
        {
            currBonus += 1;
            multiplierUI.text = "x" + currBonus;
        }
        timer = 0;
    }


}
