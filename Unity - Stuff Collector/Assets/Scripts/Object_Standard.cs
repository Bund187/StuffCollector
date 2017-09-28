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
        destroyedAudio = Instantiate(destroyedAudio);
        destroyedAudio.Play();
        Destroy(this.gameObject);
        numberDestoyed++;
        goDestroy = Instantiate(destroyed, transform.position, Quaternion.identity);
        GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(goDestroy);
        GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(destroyedAudio.gameObject);
        GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(loseAudio.gameObject);
        ScoreStuff(score);
        GameObject.Find("DestStuffScore").GetComponent<CollectedStuffScore>().RealScore += 500;
    }
    
}
