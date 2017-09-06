using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Weight : Object_ {

    public GameObject destroyedSkate;

    private float ownSpeed;
    private GameObject goDestroy;

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
        Destroy(this.gameObject);
        numberDestoyed++;
        goDestroy = Instantiate(destroyedSkate, transform.position, Quaternion.identity);
        GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(goDestroy);
    }

    public override void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * ownSpeed);
    }

    //protected override void TouchAction()
    //{
    //    Destroy(this.gameObject);
    //    numberDestoyed++;
    //}
}
