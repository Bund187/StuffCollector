using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Strawberry : Object_
{
   
    public GameObject destroyedDisk, score;
    public AudioSource diskAudio;

    private GameObject goDestroy;
    private Vector2 position;

    private void Start()
    {
        textScore = "1000";
        diskAudio = Instantiate(diskAudio);
    }

    private void OnMouseDown()
    {
        diskAudio.Play();
        position = transform.position;
        Destroy(this.gameObject);
        GameObject.Find("BonusManager").GetComponent<BonusManager>().BonusDestroyed++;
        GameObject.Find("BonusManager").GetComponent<BonusManager>().BonusReached();
        numberDestoyed++;
        goDestroy = Instantiate(destroyedDisk, transform.position, Quaternion.identity);
        GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(goDestroy);
        GameObject.Find("DestStuffScore").GetComponent<CollectedStuffScore>().RealScore += 1000;
        ScoreStuff(score);
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
