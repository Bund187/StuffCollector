using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CollectedStuffScore : MonoBehaviour {

    Text collectedStuff;

    void Start ()
    {
        collectedStuff = this.GetComponent<Text>();

    }
	
	void Update () {
        collectedStuff.text = Object_.numberDestoyed.ToString();

    }
}
