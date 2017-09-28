using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Weight : Object_ {

    public GameObject destroyedSkate, score;
    public AudioSource skateAudio, loseAudio;

    private GameObject goDestroy;

    private void Start()
    {
        textScore = "1000";
        skateAudio = Instantiate(skateAudio);
        loseAudio = Instantiate(loseAudio);
    }
    void Update()
    {
        Move();
        End();
        if (transform.position.y < -5)
        {
            loseAudio.PlayOneShot(loseAudio.clip);
        }
    }

    private void OnMouseDown()
    {
        skateAudio.Play();
        Destroy(this.gameObject);
        numberDestoyed++;
        goDestroy = Instantiate(destroyedSkate, transform.position, Quaternion.identity);
        GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(goDestroy);
        GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(skateAudio.gameObject);
        GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(loseAudio.gameObject);
        GameObject.Find("DestStuffScore").GetComponent<CollectedStuffScore>().RealScore += 1000;
        ScoreStuff(score);
    }

    public override void Move()
    {
        
        transform.Translate(Vector3.down * Time.deltaTime * (speed*2/*+ GameObject.Find("GameController").GetComponent<GameController>().LevelNumber)*/));
    }

    //protected override void TouchAction()
    //{
    //    Destroy(this.gameObject);
    //    numberDestoyed++;
    //}
}
