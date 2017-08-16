using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Uranium : Object_ {

    //public GameObject garbage;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        End();
        Touch();
    }

    private void Touch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                transform.position = touchedPos;
            }
        }

        //if (transform.position == garbage.transform.position)
        //{
        //    Destroy(this.gameObject);
        //    numberDestoyed++;
        //}
    }

    //public override void Move()
    //{
    //    transform.Translate(Vector3.down * Time.deltaTime * speed);
    //}

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
