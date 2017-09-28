using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteController : MonoBehaviour {

    public GameObject muteTrue, muteFalse, highScore;
    public AudioSource muteAudio;

    private void OnMouseDown()
    {
        if (!highScore.GetComponent<HighScoreController>().IsOn)
        {
            muteAudio.Play();
            if (gameObject.name.Contains("False"))
            {
                AudioListener.volume = 0;
                muteTrue.SetActive(true);
                gameObject.SetActive(false);
            }
            else
            {
                AudioListener.volume = 1;
                muteFalse.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}
