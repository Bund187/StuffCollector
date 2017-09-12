using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimeScore : MonoBehaviour {

    Text time;
    bool timeRunning;
    float oldTime;
    string finalTime;

    private void Awake()
    {
        oldTime = 0;
        timeRunning = true;
    }

    void Start () {
        time = this.GetComponent<Text>();
    }
	
	void Update () {
        if (timeRunning)
            time.text = string.Format("{0:00}:{1:00}", Mathf.Floor((Time.time-oldTime) / 60), Mathf.Floor(Time.time-oldTime) % 60);
        else
        {
            oldTime = Time.time;
            finalTime = time.text;
            GameObject.Find("TheEnd").GetComponent<EndManager>().totalTime.text = finalTime;
        }
    }

    public bool TimeRunning
    {
        get
        {
            return timeRunning;
        }

        set
        {
            timeRunning = value;
        }
    }

    public string FinalTime
    {
        get
        {
            return finalTime;
        }

        set
        {
            finalTime = value;
        }
    }
}
