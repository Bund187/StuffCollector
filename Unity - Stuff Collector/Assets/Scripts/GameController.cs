using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    void Update()
    {
        if (Object_.numberDestoyed == Object_.nextLevel)
        {
            print("Nivel superado");
            Object_.speed++;
            Object_.nextLevel = Object_.nextLevel * 2;
            GameObject.Find("RealSpawner").GetComponent<StuffSpawner>().RandomQuantity = GameObject.Find("RealSpawner").GetComponent<StuffSpawner>().RandomQuantity - 2;

        }


    }
}
