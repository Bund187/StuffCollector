using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Strawberry : Object_
{

    public GameObject destroyedDisk;

    private GameObject goDestroy;
    private Vector2 position;

    private void Update()
    {
       // Touch();
    }

    private void OnMouseDown()
    {
        position = transform.position;
        Destroy(this.gameObject);
        GameObject.Find("BonusManager").GetComponent<BonusManager>().BonusDestroyed++;
        GameObject.Find("BonusManager").GetComponent<BonusManager>().BonusReached();
        numberDestoyed++;
        goDestroy = Instantiate(destroyedDisk, transform.position, Quaternion.identity);
        GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(goDestroy);
    }

    //protected override void TouchAction()
    //{
    //    position = transform.position;
    //    Destroy(this.gameObject);
    //    GameObject.Find("BonusManager").GetComponent<BonusManager>().BonusDestroyed++;
    //    GameObject.Find("BonusManager").GetComponent<BonusManager>().BonusReached();
    //    numberDestoyed++;
    //}

    public Vector2 Position
    {
        get
        {
            return position;
        }

        set
        {
            position = value;
        }
    }
}
