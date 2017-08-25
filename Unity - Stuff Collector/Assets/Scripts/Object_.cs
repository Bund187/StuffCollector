using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Object_ : MonoBehaviour {

    public static int numberDestoyed = 0;
    public static float speed = 1;
    public bool isEnd = false;

    public virtual void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
    public virtual void End()
    {
        
        if (transform.position.y < -5)
        {
            if (GameObject.Find("BonusManager").GetComponent<BonusManager>().HeartCounter < 0)
            {
                Time.timeScale = 0;
                isEnd = true;
            }
            else
            {
                GameObject.Find("BonusManager").GetComponent<BonusManager>().BonusLoosing();
            }
        }
        
    }
}
