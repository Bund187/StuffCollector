using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Bomb : Object_ {

    public GameObject explosion;
    public AudioSource bombAudio;

    private GameObject goDestroy;

    private void Start()
    {
        bombAudio = Instantiate(bombAudio);
    }

    void Update()
    {
        Move();
        End();
        if (transform.position.y < -5)
        {
            GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(bombAudio.gameObject);
        }
    }

    private void OnMouseDown()
    {
        bombAudio.Play();
        goDestroy=Instantiate(explosion, transform.position, Quaternion.identity);
        GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(goDestroy);
        GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(bombAudio.gameObject);
        GameObject.Find("ShakeScreen").GetComponent<ShakeScreenController>().Shaker();
        Destroy(gameObject);
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag.Equals("Stuff") || collision.gameObject.tag.Equals("Uranium")) && !collision.name.Contains("Skate"))
        {
            Destroy(gameObject);
        }
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
