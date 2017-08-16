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
        End();
    }
    
    public override void End()
    {
        Time.timeScale = 0;
        isEnd = true;
        //TODO end of the game
    }
}
