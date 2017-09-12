using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CollectedStuffScore : MonoBehaviour {

    Text collectedStuff;
    int realScore;
    public Text finalDestroyedScore, score;

    void Start ()
    {
        collectedStuff = this.GetComponent<Text>();
        realScore = 0;
    }
	
	void Update () {
        collectedStuff.text = Object_.numberDestoyed.ToString();
        if (!GameObject.Find("TimeScore").GetComponent<TimeScore>().TimeRunning)
        {
            finalDestroyedScore.text = collectedStuff.text;
            score.text = realScore.ToString();
        }
        
        
        
    }

    public int RealScore
    {
        get
        {
            return realScore;
        }

        set
        {
            realScore = value;
        }
    }
}
