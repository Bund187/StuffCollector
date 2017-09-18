using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Star : Object_ {

    public GameObject score;
    public AudioSource starDestroyAudio, starAppearAudio;

    private void Start()
    {
        textScore = "5000";
        starDestroyAudio = Instantiate(starDestroyAudio);
        starAppearAudio = Instantiate(starAppearAudio);
        starAppearAudio.Play();
    }
    void Update()
    {
        Move();
    }

    private void OnMouseDown()
    {
        starAppearAudio.Stop();
        starDestroyAudio.Play();
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
        ScoreStuff(score);
        GameObject.Find("DestStuffScore").GetComponent<CollectedStuffScore>().RealScore += 5000;
    }

    public override void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * (speed + GameObject.Find("GameController").GetComponent<GameController>().LevelNumber));
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
