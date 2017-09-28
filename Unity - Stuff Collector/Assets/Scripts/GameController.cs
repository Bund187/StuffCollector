using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

    private float nextLevel;
    private int levelNumber, index;
    private bool isTutorial, firstTouch;
    private string[] TutorialTexts = new string[10];
   
    public GameObject rider, riderIn, riderOut, newLevel, tutorialTxt,txtShadow,transition, background, animBackground,clicMiss;
    public GameObject[] stuffs = new GameObject[8];
    public GameObject[] arrows = new GameObject[8];
    
    private void Awake()
    {
        index = 0;
        nextLevel = 10;
        levelNumber = 1;
        if(GameObject.FindGameObjectWithTag("TutorialCheck"))
        {
            Destroy(GameObject.FindGameObjectWithTag("TutorialCheck"));
        }
        isTutorial = true;
        if (TutorialCheckBoxManager.isTutorialOn)
        {
            background.SetActive(true);
            animBackground.SetActive(false);
            clicMiss.SetActive(false);
        }
    }

    private void Start()
    {
        TutorialTexts[0] = "Tha Rider here. There's some stuff falling from the sky and I'm gonna show you how destroy them.\r\n -Tap to continue-";
        TutorialTexts[1] = "First we got the Casette. Easy to break, just tap it.";
        TutorialTexts[2] = "Then we got the TV, tap it three times to destroy it.";
        TutorialTexts[3] = "This here is the Roller Skate, also one tap to finish it. Falls pretty fast, though.";
        TutorialTexts[4] = "The next one is the Bomb. Don't tap it or you'll die.";
        TutorialTexts[5] = "Yes! The Star, tap it to clean the screen.";
        TutorialTexts[6] = "And the last one, The Virtual Glasses, when tapped all objects on screen will turn...";
        TutorialTexts[7] = "...Floppy Disks! If you destroy all of them a life will be added to a max of 3.";
        TutorialTexts[8] = "Aight! That is all. Sit back, relax and enjoy. \r\n -Tap to continue-";
        firstTouch = true;
    }

    void Update()
    {
        if(transition.GetComponent<TransitionStartManager>().Alpha<=0)
            if (TutorialCheckBoxManager.isTutorialOn) Tutorial();

        LevelUp();
        
    }

   

    public void Tutorial()
    {
        if (index <= 8)
        {
            GameObject.Find("RealSpawner").GetComponent<StuffSpawner>().NoSpawn = true;
            riderIn.SetActive(true);
            if(riderIn.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !riderIn.GetComponent<Animator>().IsInTransition(0))
            {
                rider.SetActive(true);
            }
            if (rider.activeSelf == true)
            {
                riderIn.SetActive(false);
                GameObject.Find("TextAppear").GetComponent<TextAppearanceManager>().TextAppeareance(tutorialTxt.GetComponent<Text>(), txtShadow.GetComponent<Text>(), TutorialTexts[index].ToCharArray());


                if (index > 0 && index < 8)
                {
                    if (stuffs[index - 1] != null)
                    {
                        stuffs[index - 1].SetActive(true);
                    }
                    arrows[index-1].SetActive(true);
                    
                    if (stuffs[index - 1] == null)
                    {

                        if (index > 0 && index < 8)
                        {
                            arrows[index - 1].SetActive(false);
                        }

                        GameObject.Find("TextAppear").GetComponent<TextAppearanceManager>().ResetTextAppeareance(tutorialTxt.GetComponent<Text>(), txtShadow.GetComponent<Text>());
                        index++;
                    }
                }
                if (GameObject.Find("TextAppear").GetComponent<TextAppearanceManager>().Index >= TutorialTexts[index].ToCharArray().Length && index >= 8)
                {
                    print("index=" + index);
                    firstTouch = true;
                }
                if (GameObject.Find("TextAppear").GetComponent<TextAppearanceManager>().Index>= TutorialTexts[index].ToCharArray().Length)
                {
                    if ((Input.GetMouseButtonDown(0) && firstTouch))
                    {
                        if (index > 0 && index < 8)
                        {
                            stuffs[index-1].SetActive(false);
                            arrows[index-1].SetActive(false);
                        }

                        GameObject.Find("TextAppear").GetComponent<TextAppearanceManager>().ResetTextAppeareance(tutorialTxt.GetComponent<Text>(), txtShadow.GetComponent<Text>());
                        index++;
                        firstTouch = false;
                    }
                }
            }
        }
        else {

            rider.SetActive(false);
            riderOut.SetActive(true);
            GameObject.Find("RealSpawner").GetComponent<StuffSpawner>().NoSpawn = false;
            TutorialCheckBoxManager.isTutorialOn = false;
            background.SetActive(false);
            animBackground.SetActive(true);
            clicMiss.SetActive(true);
        }



    }

    public void LevelUp()
    {
        if (Object_.numberDestoyed >= nextLevel)
        {
            levelNumber++;
            Object_.speed += 0.3f;
            nextLevel = nextLevel * 1.5f;
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
    public float NextLevel
    {
        get
        {
            return nextLevel;
        }

        set
        {
            nextLevel = value;
        }
    }
    
}
