using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseHighScoreController : MonoBehaviour {

    public GameObject highScoreOff,highScoreOn,highScoreManager;
    public GameObject[] rankings;
    public GameObject[] actionFigures;

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
        foreach(GameObject rankin in rankings)
        {
            if (rankin.activeSelf)
                rankin.SetActive(false);
        }
        foreach(GameObject af in actionFigures)
        {
            if (af.activeSelf)
                af.SetActive(false);
        }

        highScoreOn.SetActive(false);
        highScoreOff.SetActive(true);
        highScoreManager.GetComponent<HighScoreController>().IsOn = false;
    }
}
