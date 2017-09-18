using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Diamond : Object_ {

    private int durability;
    private float startTime;
    private GameObject goDestroy;

    public GameObject brokenTv, destroyedTv, score;
    public Sprite[] sprites = new Sprite[3];
    public AudioSource[] tvAudio=new AudioSource[3];
    public AudioSource loseAudio;

    private void Start()
    {
        brokenTv=Instantiate(brokenTv, transform.position, Quaternion.identity);
        durability = 0;
        for (int j=0;j<tvAudio.Length; j++) { 
            tvAudio[j] = Instantiate(tvAudio[j]);
        }
        loseAudio = Instantiate(loseAudio);
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
        if (transform.position.y < -5)
        {
            loseAudio.PlayOneShot(loseAudio.clip);
        }
    }

    private void OnMouseDown()
    {
        tvAudio[durability].Play();
        durability++;
        
        if (durability >= 3)
        {
            
            Destroy(this.gameObject);
            numberDestoyed++;
            goDestroy=Instantiate(destroyedTv, transform.position, Quaternion.identity);
            GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(goDestroy);
            textScore = "1000";
            GameObject.Find("DestStuffScore").GetComponent<CollectedStuffScore>().RealScore += 1000;
        }
        else
        {
            brokenTv.SetActive(true);
            startTime = Time.time;
            textScore = "500";
            GameObject.Find("DestStuffScore").GetComponent<CollectedStuffScore>().RealScore += 500;
        }
        ScoreStuff(score);
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
