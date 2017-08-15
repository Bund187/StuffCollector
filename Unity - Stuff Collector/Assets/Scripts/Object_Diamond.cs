using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Diamond : Object_ {

    public int durability=0;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        End();
    }

    private void OnMouseDown()
    {
        durability++;
        if (durability >= 5)
        {
            Destroy(this.gameObject);
            numberDestoyed++;
        }
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
