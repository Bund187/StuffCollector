using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Object_ : MonoBehaviour {

    public static int numberDestoyed = 0;
    public static float speed = 1;
    protected bool isEnd = false;

    public virtual void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
    public abstract void End();
    
}
