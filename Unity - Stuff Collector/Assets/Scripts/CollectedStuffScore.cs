using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CollectedStuffScore : MonoBehaviour {

    Text collectedStuff;
    int realScore;
    public Text finalDestroyedScore, score, actionFigureName;
    public SpriteRenderer[] actionFigures;
    public SpriteRenderer actionFigureFrame;
    
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

    public void ShowActionFigure()
    {
        //if(realScore>=0 && realScore <= 99000)
        //{

        //}
        //else if (realScore >= 100000 && realScore <= 199000)
        //{

        //}
        //else if (realScore >= 200000 && realScore <= 399000)
        //{

        //}
        //else if (realScore >= 300000 && realScore <= 499000)
        //{

        //}
        //else if (realScore >= 400000 && realScore <= 599000)
        //{

        //}
        //else 
        //{

        //}

        if /*(realScore >= 0 && realScore <= 499)*/(realScore >= 0 && realScore <= 99000)
        {
            actionFigureFrame.sprite = actionFigures[0].sprite;
            actionFigureName.text = "Steffen Urkelson";
        }
        else if /*(realScore >= 500 && realScore <= 999)*/(realScore >= 100000 && realScore <= 199000)
        {
            actionFigureFrame.sprite = actionFigures[1].sprite;
            actionFigureName.text = "Martin McFlought";
        }
        else if /*(realScore >= 1000 && realScore <= 1499)*/(realScore >= 200000 && realScore <= 399000)
        {
            actionFigureFrame.sprite = actionFigures[2].sprite;
            actionFigureName.text = "Maikel Night";
        }
        else if /*(realScore >= 1500 && realScore <= 1999)*/(realScore >= 300000 && realScore <= 499000)
        {
            actionFigureFrame.sprite = actionFigures[3].sprite;
            actionFigureName.text = "Rey Stunt";
        }
        else if /*(realScore >= 2000 && realScore <= 2499)*/(realScore >= 400000 && realScore <= 599000)
        {
            actionFigureFrame.sprite = actionFigures[4].sprite;
            actionFigureName.text = "Indian Jons";
        }
        else
        {
            actionFigureFrame.sprite = actionFigures[5].sprite;
            actionFigureName.text = "Finishator";
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
