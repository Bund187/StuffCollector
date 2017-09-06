using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Bomb : Object_ {

    public GameObject explosion;

    private GameObject goDestroy;
    
    void Update()
    {
        Move();
    }

    private void OnMouseDown()
    {
        goDestroy=Instantiate(explosion, transform.position, Quaternion.identity);
        GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(goDestroy);
        Destroy(gameObject);
        
    }
    
    //protected override void TouchAction()
    //{
    //    Destroy(this.gameObject);
    //    print("heart nº=" + GameObject.Find("BonusManager").GetComponent<BonusManager>().HeartCounter);
    //    if (GameObject.Find("BonusManager").GetComponent<BonusManager>().HeartCounter < 0)
    //    {
    //        End();
    //    }
    //    else
    //    {
    //        GameObject.Find("BonusManager").GetComponent<BonusManager>().BonusLoosing();
    //    }
    //}
}
