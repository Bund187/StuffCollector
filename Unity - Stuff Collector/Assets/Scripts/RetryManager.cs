﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RetryManager : MonoBehaviour {

    public Text[] scoreToReset;
    public GameObject stuffSpawner, gameOverBackg,theEnd, redFilter, gameController,timeController;
    public GameObject[] gameoverGos;
    public AudioSource gameoverAudio;

    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if(theEnd.GetComponent<EndManager>().IsEnd)
                Reset();
        }
	}

    public void Reset()
    {
        gameoverAudio.Stop();
        foreach(Text go in scoreToReset)
        {
            if (go.name.Equals("TimeScore"))
                go.text = "00:00";
            else if (go.name.Equals("NewLevelScore"))
                go.text = "1";
            else
                go.text = "0";

        }
        Object_.numberDestoyed = 0;
        Object_.speed = 1;
        gameController.GetComponent<GameController>().NextLevel = 10;
        gameController.GetComponent<GameController>().LevelNumber = 1;
        stuffSpawner.GetComponent<StuffSpawner>().NoSpawn = false;
        gameOverBackg.SetActive(false);
        redFilter.SetActive(false);
        foreach(GameObject go in gameoverGos)
        {
            go.SetActive(false);
        }
        timeController.GetComponent<TimeScore>().TimeRunning = true;
        theEnd.GetComponent<EndManager>().IsEnd = false;
    }
    
}
