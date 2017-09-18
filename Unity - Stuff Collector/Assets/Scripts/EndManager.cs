using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndManager : MonoBehaviour
{
    bool isEnd;

    public GameObject gameOverBackground, filter;
    public GameObject[] gameOverGos;
    public Text totalTime;
    public AudioSource gameoverAudio;

    private void Update()
    {
        if (isEnd)
        {
            End();
            if (gameOverBackground.activeSelf)
            {
                gameoverAudio.PlayOneShot(gameoverAudio.clip);

                if (gameOverBackground.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !gameOverBackground.GetComponent<Animator>().IsInTransition(0))
                {
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
