using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Diamond : Object_ {

    private int durability=0;

    void Update()
    {
        Move();
        End();
    }

    private void OnMouseDown()
    {
        durability++;
        if (durability >= 3)
        {
            Destroy(this.gameObject);
            numberDestoyed++;
        }
    }

    public override void End()
    {
        if (transform.position.y < -5)
        {
            Time.timeScale = 0;
            isEnd = true;
        }

        //TODO end of the game
    }
}
