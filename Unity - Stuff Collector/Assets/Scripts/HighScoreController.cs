using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreController : MonoBehaviour {

    public GameObject showHighScoreOn, close;

    bool isOn;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (showHighScoreOn.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !showHighScoreOn.GetComponent<Animator>().IsInTransition(0))
        {
            close.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        isOn = true;
        showHighScoreOn.SetActive(true);

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
