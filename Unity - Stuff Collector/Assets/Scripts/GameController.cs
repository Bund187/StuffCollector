using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private int nextLevel = 10;
    private int levelNumber = 1;
    private bool isTutorial = false;
    private float cuakSpeed = 1;

    public GameObject cuak, cuakAnim, newLevel, globeUp, globeDown, tutorialTxt;

    void Update()
    {
        if (isTutorial) Tutorial();

        LevelUp();
    }

    public void Tutorial()
    {
        cuak.transform.position = Vector2.MoveTowards(cuak.transform.position, cuakAnim.transform.position,cuakSpeed*Time.deltaTime);
        if (cuak.transform.position == cuakAnim.transform.position)
        {
            cuakAnim.SetActive(true);
            cuak.SetActive(false);
            globeUp.SetActive(true);
            
            if (globeUp.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !globeUp.GetComponent<Animator>().IsInTransition(0))
            {
                //print("se acabo la animacion: "+ globeUp.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0));
                cuak.SetActive(true);
                cuakAnim.SetActive(false);
                tutorialTxt.SetActive(true);

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
