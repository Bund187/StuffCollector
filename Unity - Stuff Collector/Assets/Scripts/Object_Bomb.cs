using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Bomb : Object_ {

    public GameObject explosion;
    public AudioSource bombAudio;

    private GameObject goDestroy;
    
    void Update()
    {
        Move();
        End();
        bombAudio = Instantiate(bombAudio);
    }

    private void OnMouseDown()
    {
        bombAudio.Play();
        goDestroy=Instantiate(explosion, transform.position, Quaternion.identity);
        GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(goDestroy);
        GameObject.Find("ShakeScreen").GetComponent<ShakeScreenController>().Shaker();
        //GameObject.Find("TheEnd").GetComponent<EndManager>().gameOverBackground.SetActive(true);
        Destroy(gameObject);
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        print("colision");
        if (collision.gameObject.tag.Equals("Stuff") && !collision.name.Contains("Skate"))
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
