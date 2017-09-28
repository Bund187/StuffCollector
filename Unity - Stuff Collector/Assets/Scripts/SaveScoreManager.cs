using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScoreManager : MonoBehaviour {

    public GameObject highScore;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("TimeScore").GetComponent<TimeScore>().TimeRunning)
        {
            
        }
    }
}
