using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private int nextLevel = 10;
    private int levelNumber = 1;

    public GameObject newLevel;

    void Update()
    {
        if (Object_.numberDestoyed == nextLevel)
        {
            print("Nivel superado");
            levelNumber++;
            Object_.speed+=0.3f;
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
}
