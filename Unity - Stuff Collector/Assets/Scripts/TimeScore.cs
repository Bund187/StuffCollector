using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimeScore : MonoBehaviour {

    Text time;

	void Start () {
        time = this.GetComponent<Text>();
    }
	
	void Update () {
        time.text = string.Format("{0:00}:{1:00}", Mathf.Floor(Time.time / 60), Mathf.Floor(Time.time) % 60);
    }
}
