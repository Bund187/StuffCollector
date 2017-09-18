using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Standard : Object_ {

    public GameObject destroyed, score;
    public AudioSource destroyedAudio, loseAudio;

    private GameObject goDestroy;

    private void Start()
    {
        textScore = "500";
        destroyedAudio = Instantiate(destroyedAudio);
        loseAudio = Instantiate(loseAudio);
    }

    void Update()
    {
        Move();
        End();
        if (transform.position.y < -5)
        {
            loseAudio.PlayOneShot(loseAudio.clip);
            print("se cayó");
        }
    }

    private void OnMouseDown()
    {
        destroyedAudio.Play();
        Destroy(this.gameObject);
        numberDestoyed++;
        goDestroy = Instantiate(destroyed, transform.position, Quaternion.identity);
        GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(goDestroy);
        ScoreStuff(score);
        GameObject.Find("DestStuffScore").GetComponent<CollectedStuffScore>().RealScore += 500;
    }

    //private void Touching()
    //{
    //    for (int i = 0; i < Input.touchCount; ++i)
    //    {
    //        if (Input.GetTouch(i).phase == TouchPhase.Began)
    //        {
    //            // Construct a ray from the current touch coordinates
    //            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
    //            // Create a particle if hit
    //            if (Physics.Raycast(ray))
    //            {
    //                Destroy(this.gameObject);
    //                numberDestoyed++;
    //            }
    //        }
    //    }
    //}

    //protected override void TouchAction()
    //{
    //    Destroy(this.gameObject);
    //    numberDestoyed++;
    //}
}
