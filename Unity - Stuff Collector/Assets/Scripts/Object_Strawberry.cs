using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Strawberry : Object_
{
    private Vector2 position;

    private void OnMouseDown()
    {
        position = transform.position;
        Destroy(this.gameObject);
        numberDestoyed++;
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


    public Vector2 Position
    {
        get
        {
            return position;
        }

        set
        {
            position = value;
        }
    }
}
