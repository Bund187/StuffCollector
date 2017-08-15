using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Object_ : MonoBehaviour {

    public static int nextLevel = 10;
    public static int numberDestoyed = 0;
    public static float speed = 1;
    protected bool isEnd = false;
    
    public abstract void Move();
    public abstract void End();

    
    

}
