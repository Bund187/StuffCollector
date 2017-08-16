using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelScore : MonoBehaviour {

    Text levelScore;

	void Start () {
        levelScore = this.GetComponent<Text>();
	}
	
	void Update () {
        levelScore.text = GameObject.Find("GameController").GetComponent<GameController>().LevelNumber.ToString();
	}
}
