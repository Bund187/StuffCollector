using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCheckBoxManager : MonoBehaviour {

    public GameObject tutorialTrue, tutorialFalse;

    public static bool isTutorialOn;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void OnMouseDown()
    {
        if (gameObject.name.Contains("False"))
        {
            isTutorialOn = true;
            tutorialTrue.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            isTutorialOn = false;
            tutorialFalse.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    
}
