using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseHighScoreController : MonoBehaviour {

    public GameObject highScoreOff,highScoreOn;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (highScoreOff.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !highScoreOff.GetComponent<Animator>().IsInTransition(0))
        {
            highScoreOff.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        highScoreOn.SetActive(false);
        highScoreOff.SetActive(true);
    }
}
