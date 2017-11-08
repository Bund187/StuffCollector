using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HighScoreController : MonoBehaviour {

    public GameObject showHighScoreOn, close;
    public GameObject[] rankings;
    public GameObject[] actionFigures;
    bool isOn;

    // Update is called once per frame
    void Update()
    {
        if (showHighScoreOn.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !showHighScoreOn.GetComponent<Animator>().IsInTransition(0))
        {
            close.SetActive(true);
            ShowActionFigure();
        }
    }

    private void OnMouseDown()
    {
        isOn = true;
        showHighScoreOn.SetActive(true);

    }

    public void ShowActionFigure()
    {
        if /*(realScore >= 0 && realScore <= 499)*/(PlayerPrefs.GetInt("SteveScore") > 0)
        {
            rankings[0].SetActive(true);
            rankings[1].SetActive(true);
            rankings[1].GetComponent<Text>().text = PlayerPrefs.GetInt("SteveScore").ToString()+ " Points\n Next @ 100000 Points";
            actionFigures[0].SetActive(true);
        }
        if /*(realScore >= 500 && realScore <= 999)*/(PlayerPrefs.GetInt("MartinScore") >= 100000)
        {
            rankings[2].SetActive(true);
            rankings[3].SetActive(true);
            rankings[3].GetComponent<Text>().text = PlayerPrefs.GetInt("MartinScore").ToString() + " Points\n Next @ 200000 Points";
            actionFigures[1].SetActive(true);
        }
        if /*(realScore >= 1000 && realScore <= 1499)*/(PlayerPrefs.GetInt("MaikelScore") >= 200000)
        {
            rankings[4].SetActive(true);
            rankings[5].SetActive(true);
            rankings[5].GetComponent<Text>().text = PlayerPrefs.GetInt("MaikelScore").ToString() + " Points\n Next @ 300000 Points";
            actionFigures[2].SetActive(true);
        }
        if /*(realScore >= 1500 && realScore <= 1999)*/(PlayerPrefs.GetInt("ReyScore") >= 300000)
        {
            rankings[6].SetActive(true);
            rankings[7].SetActive(true);
            rankings[7].GetComponent<Text>().text = PlayerPrefs.GetInt("ReyScore").ToString() + " Points\n Next @ 400000 Points";
            actionFigures[3].SetActive(true);
        }
        if /*(realScore >= 2000 && realScore <= 2499)*/(PlayerPrefs.GetInt("IndianScore") >= 400000)
        {
            rankings[8].SetActive(true);
            rankings[9].SetActive(true);
            rankings[9].GetComponent<Text>().text = PlayerPrefs.GetInt("IndianScore").ToString() + " Points\n Next @ 599000 Points";
            actionFigures[4].SetActive(true);
        }
        if (PlayerPrefs.GetInt("FinishatorScore") > 599000)
        {
            rankings[10].SetActive(true);
            rankings[11].SetActive(true);
            rankings[11].GetComponent<Text>().text = PlayerPrefs.GetInt("FinishatorScore").ToString() + " Points\n No next, YOU WIN!";
            actionFigures[5].SetActive(true);
        }

    }

    public bool IsOn
    {
        get
        {
            return isOn;
        }

        set
        {
            isOn = value;
        }
    }
}
