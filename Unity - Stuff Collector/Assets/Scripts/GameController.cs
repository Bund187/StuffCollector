using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

    private int nextLevel, levelNumber, index;
    private bool isTutorial;
    private float cuakSpeed;
    private string[] TutorialTexts = new string[10];
    private bool animEnd = false;

    public GameObject cuak, cuakAnim, newLevel, globeUp, globeDown, tutorialTxt,cuakPosition;
    public GameObject[] stuffs = new GameObject[8];
    public GameObject[] arrows = new GameObject[8];

    private void Awake()
    {
        index = 0;
        nextLevel = 10;
        levelNumber = 1;
        cuakSpeed = 1;
        isTutorial = false;
    }

    private void Start()
    {
        TutorialTexts[0] = "Hello I'm Paco and I'm here to show you the different kind of stuff that may fall from the sky.";
        TutorialTexts[1] = "First we got the blue cristal. Easy to break, just tap it.";
        TutorialTexts[2] = "Then we got the Diamond, tap it twice to destroy it.";
        TutorialTexts[3] = "This here is the Weight, one tap to finish it but falls pretty fast.";
        TutorialTexts[4] = "The next one is the bomb. Don't tap it or will explode.";
        TutorialTexts[5] = "Oh! This is the Star, tap it to clean the screen.";
        TutorialTexts[6] = "And the last one is the Uranium, when tapped all objects on screen will turn...";
        TutorialTexts[7] = "...Strawberries! If you destroy all of them a life will added to a maximum of 3.";
        TutorialTexts[8] = "Allright! That is all. Sit back, relax and enjoy. Bye bye!";
        cuak.transform.position = new Vector2(cuakPosition.transform.position.x+1, cuakPosition.transform.position.y);

    }

    void Update()
    {
        if (isTutorial) Tutorial();

        LevelUp();
    }

    public void Tutorial()
    {
        if (index <= 8)
        {
            cuak.SetActive(true);
            cuak.transform.position = Vector2.MoveTowards(cuak.transform.position, cuakAnim.transform.position, cuakSpeed * Time.deltaTime);
            if (cuak.transform.position == cuakAnim.transform.position)
            {
                cuakAnim.SetActive(true);
                cuak.SetActive(false);
                globeUp.SetActive(true);
            }
            if (globeUp.activeSelf)
            {
                if (globeUp.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !globeUp.GetComponent<Animator>().IsInTransition(0))
                {
                    cuak.SetActive(true);
                    cuakAnim.SetActive(false);
                    tutorialTxt.GetComponent<Text>().text = TutorialTexts[index];
                    tutorialTxt.SetActive(true);
                    if (index > 0 && index < 8)
                    {
                        stuffs[index - 1].SetActive(true);
                        arrows[index - 1].SetActive(true);
                    }
                }
            }
            if (/*Input.touchCount > 0*/ Input.GetMouseButtonDown(0))
            {

                if (index > 0 && index < 8)
                {
                    stuffs[index - 1].SetActive(false);
                    arrows[index - 1].SetActive(false);
                }
                tutorialTxt.SetActive(false);
                globeUp.SetActive(false);
                index++;
            }
        }
        else
        {
            cuakAnim.SetActive(false);
            cuak.SetActive(true);
            globeUp.SetActive(false);
            globeDown.SetActive(true);
            if (globeDown.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !globeUp.GetComponent<Animator>().IsInTransition(0))
            {
                animEnd = true;
            }
            if (animEnd)
            {
                globeDown.SetActive(false);
                cuak.transform.position = Vector2.MoveTowards(cuak.transform.position, new Vector2(cuakPosition.transform.position.x + 1, cuakPosition.transform.position.y), cuakSpeed * Time.deltaTime);
            }
            if((Vector2)cuak.transform.position== new Vector2(cuakPosition.transform.position.x + 1, cuakPosition.transform.position.y))
            {
                GameObject.Find("RealSpawner").GetComponent<StuffSpawner>().NoSpawn = false;
                cuak.SetActive(false);
                isTutorial = false;
            }

        }



    }

    public void LevelUp()
    {
        if (Object_.numberDestoyed == nextLevel)
        {
            print("Nivel superado");
            levelNumber++;
            Object_.speed += 0.3f;
            nextLevel = nextLevel * 2;
            GameObject.Find("RealSpawner").GetComponent<StuffSpawner>().RandomQuantity = GameObject.Find("RealSpawner").GetComponent<StuffSpawner>().RandomQuantity - 2;
            newLevel.SetActive(true);

        }
    }
    public int LevelNumber
    {
        get
        {
            return levelNumber;
        }

        set
        {
            levelNumber = value;
        }
    }

    public bool IsTutorial
    {
        get
        {
            return isTutorial;
        }

        set
        {
            isTutorial = value;
        }
    }
}
