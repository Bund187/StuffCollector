using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Bomb : Object_ {

    void Update()
    {
        Move();
    }

    private void OnMouseDown()
    {
        Destroy(this.gameObject);
        print("heart nº=" + GameObject.Find("BonusManager").GetComponent<BonusManager>().HeartCounter);
        if (GameObject.Find("BonusManager").GetComponent<BonusManager>().HeartCounter < 0)
        {
            End();
        }
        else
        {
            GameObject.Find("BonusManager").GetComponent<BonusManager>().BonusLoosing();
        }
    }
    
    public override void End()
    {
        Time.timeScale = 0;
        isEnd = true;
        //TODO end of the game
    }
}
