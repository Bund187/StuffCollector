using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour {

    public int speed = 1;

    private bool isEnd = false;

    void Update() {
        Move();
        End();
       
    }

    private void OnMouseDown()
    {
        Destroy(this.gameObject);
    }

    private void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    private void End()
    {
        if (transform.position.y < -7)
        {
            Time.timeScale = 0;
            isEnd = true;
        }
        
        //TODO end of the game
    }

    public bool IsEnd
    {
        get
        {
            return isEnd;
        }

        set
        {
            isEnd = value;
        }
    }
}
