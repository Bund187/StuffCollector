using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour {

    bool changeScene, clicAvailable;
    float startTime;
    
    public GameObject transition, highScore;
    public AudioSource theme, tapAudio;

    private void Awake()
    {
        startTime = Time.time;
    }
    void Update () {
        if (Time.time >= startTime + 0.3)
        {
            clicAvailable = true;
        }

        if (changeScene)
        {
            
            transition.SetActive(true);
            theme.volume -= 0.009f;
            if (theme.volume <= 0)
            {
                SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
            }
        }
    }

    private void OnMouseDown()
    {
        if (clicAvailable && !highScore.GetComponent<HighScoreController>().IsOn)
        {
            tapAudio.Play();
            changeScene = true;
        }
    }
}
