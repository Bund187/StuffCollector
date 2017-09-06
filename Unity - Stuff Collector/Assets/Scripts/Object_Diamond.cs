using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Diamond : Object_ {

    private int durability=0;
    private float startTime;
    private GameObject goDestroy;

    public GameObject brokenTv, destroyedTv;
    public Sprite[] sprites = new Sprite[3];

    private void Start()
    {
        brokenTv=Instantiate(brokenTv, transform.position, Quaternion.identity);
    }

    void Update()
    {
        brokenTv.transform.Translate(Vector3.down * Time.deltaTime * speed);
        Move();
        End();

        if (Time.time >= startTime + 0.1f)
        {
            brokenTv.SetActive(false);
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[durability];
        }

    }

    private void OnMouseDown()
    {
        durability++;
        
        if (durability >= 3)
        {
            Destroy(this.gameObject);
            numberDestoyed++;
            goDestroy=Instantiate(destroyedTv, transform.position, Quaternion.identity);
            GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(goDestroy);
        }
        else
        {
            brokenTv.SetActive(true);
            startTime = Time.time;
        }
    }
    
    //protected override void TouchAction()
    //{
    //    durability++;
    //    if (durability >= 3)
    //    {
    //        Destroy(this.gameObject);
    //        numberDestoyed++;
    //    }
    //}
}
