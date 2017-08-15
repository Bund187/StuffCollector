using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Star : Object_ {

    private void Start()
    {
        //Speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        End();
    }

    private void OnMouseDown()
    {
        
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Stuff");
        if (gos.Length > 0)
        {
            for(int i = 0; i < gos.Length; i++)
            {
                Destroy(gos[i]);
            }
        }
            
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
