using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndManager : MonoBehaviour
{
    bool isEnd;
    GameObject[] audios;

    public GameObject gameOverBackground, filter, missClic, background, animBackground, showFigure;
    public GameObject[] gameOverGos;
    public Text totalTime;
    public AudioSource gameoverAudio, mainThemeAudio;

    private void Update()
    {
        if (isEnd)
        {
            End();
            if (gameOverBackground.activeSelf)
            {
                mainThemeAudio.Stop();
                gameoverAudio.PlayOneShot(gameoverAudio.clip);
                if (gameOverBackground.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !gameOverBackground.GetComponent<Animator>().IsInTransition(0))
                {
                    showFigure.GetComponent<CollectedStuffScore>().ShowActionFigure();
                    foreach (GameObject go in gameOverGos)
                    {
                        go.SetActive(true);
                    }
                    
                }
            }
        }
    }


    public void End()
    {
        background.SetActive(true);
        animBackground.SetActive(false);
        missClic.GetComponent<ClicPositionManager>().IsGameOver = true;
        audios = GameObject.FindGameObjectsWithTag("Audio");
        foreach(GameObject goAudio in audios)
        {
            goAudio.GetComponent<AudioSource>().volume = 0;
        }
        if (isEnd)
        {
            GameObject.Find("TimeScore").GetComponent<TimeScore>().TimeRunning = false;
            gameOverBackground.SetActive(true);
            filter.SetActive(true);
            GameObject.Find("RealSpawner").GetComponent<StuffSpawner>().NoSpawn = true;
            List<GameObject> goToDestroy = Utils.FindInLayer();
            foreach (GameObject go in goToDestroy)
            {
                Destroy(go);
            }
        }
    }

    public bool IsEnd
    {
        get
        {
            return isEnd;
        }

        set
        {
            isEnd = value;
        }
    }

}
