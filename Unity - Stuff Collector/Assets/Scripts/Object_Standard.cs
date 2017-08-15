using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Standard : Object_ {

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update () {
        Move();
        End();
	}

    private void OnMouseDown()
    {
        Destroy(this.gameObject);
        numberDestoyed++;
    }

    public override void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
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
