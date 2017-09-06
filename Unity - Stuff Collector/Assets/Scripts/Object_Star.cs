using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Star : Object_ {

    private float ownSpeed;

    private void Start()
    {
        ownSpeed = 3;
    }
    void Update()
    {
        Move();
        End();
        
    }

    private void OnMouseDown()
    {
        GameObject.Find("ScreenFlash").GetComponent<ScreenFlash>().IsFlashing = true;
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Stuff");
        if (gos.Length > 0)
        {
            for (int i = 0; i < gos.Length; i++)
            {
                Destroy(gos[i]);
            }
        }
        
        Destroy(this.gameObject);
        numberDestoyed++;
        
    }

    public override void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * ownSpeed);
    }

    
    //protected override void TouchAction()
    //{
    //    GameObject[] gos = GameObject.FindGameObjectsWithTag("Stuff");
    //    if (gos.Length > 0)
    //    {
    //        for (int i = 0; i < gos.Length; i++)
    //        {
    //            Destroy(gos[i]);
    //        }
    //    }

    //    Destroy(this.gameObject);
    //    numberDestoyed++;
    //}
}
