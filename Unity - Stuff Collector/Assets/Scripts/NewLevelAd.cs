using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NewLevelAd : MonoBehaviour {

    Text newLevel;
    public Text score;

	void Start () {
        newLevel = this.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        score.text = GameObject.Find("GameController").GetComponent<GameController>().LevelNumber.ToString();
        LevelManager();
	}

    void LevelManager()
    {
        if (newLevel.fontSize < 100)
        {
            newLevel.fontSize++;
            score.fontSize++;
        }
        if (newLevel.fontSize >= 100)
        {
            newLevel.fontSize = 14;
            score.fontSize = 14;
            this.gameObject.SetActive(false);
        }
    }
}
