using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionStartManager : MonoBehaviour {

    public GameObject stuffSpawner, tutorialController;
    
    float alpha;
    bool done;

    void Start () {
        stuffSpawner.GetComponent<StuffSpawner>().NoSpawn = true;
        alpha = GetComponent<RawImage>().color.a;
    }
	
	void Update () {
        if (GetComponent<RawImage>().color.a > 0)
        {
            alpha -= 0.01f;
            GetComponent<RawImage>().color = new Color(GetComponent<RawImage>().color.r, GetComponent<RawImage>().color.g, GetComponent<RawImage>().color.b,alpha);

        }
        else 
        {
            alpha = 0;
            GetComponent<RawImage>().color = new Color(GetComponent<RawImage>().color.r, GetComponent<RawImage>().color.g, GetComponent<RawImage>().color.b, alpha);
            if (!TutorialCheckBoxManager.isTutorialOn)
            {
                if (!done)
                {
                    stuffSpawner.GetComponent<StuffSpawner>().NoSpawn = false;
                    done = true;
                }
            }
        }
        
    }
    public float Alpha
    {
        get
        {
            return alpha;
        }

        set
        {
            alpha = value;
        }
    }

}
