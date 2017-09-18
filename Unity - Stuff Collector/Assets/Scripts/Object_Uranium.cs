using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Uranium : Object_ {

    public GameObject destroyed, score;
    public AudioSource glassesAudio, loseAudio;

    private GameObject goDestroy;

    private void Start()
    {
        textScore = "1500";
        glassesAudio = Instantiate(glassesAudio);
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
        glassesAudio.Play();
        GameObject.Find("BonusManager").GetComponent<BonusManager>().IsManagerOn = true;
        GameObject.Find("BonusManager").GetComponent<BonusManager>().Manager();
        goDestroy = Instantiate(destroyed, transform.position, Quaternion.identity);
        GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(goDestroy);
        GameObject.Find("DestStuffScore").GetComponent<CollectedStuffScore>().RealScore += 1500;
        ScoreStuff(score);
    }

    //protected override void TouchAction()
    //{
    //    GameObject.Find("BonusManager").GetComponent<BonusManager>().IsManagerOn = true;
    //    GameObject.Find("BonusManager").GetComponent<BonusManager>().Manager();
    //}

    //private void Touch()
    //{
    //    Vector2 dragPosition=new Vector2(0,0);

    //    if (Input.touchCount > 0)
    //    {
    //        Touch touch = Input.GetTouch(0);

    //        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
    //        RaycastHit2D raycastHit = Physics2D.Raycast(worldPoint, Vector2.zero);
    //        if (raycastHit.collider!=null)
    //        {
    //            if (raycastHit.collider.name.Equals(this.gameObject.name))
    //            {

    //                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Began)
    //                {
    //                    Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
    //                    transform.position = touchedPos;
    //                }
    //                if(touch.phase == TouchPhase.Ended)
    //                {
    //                    dragPosition = touch.position;
    //                    isTouching = true;
    //                }
    //            }
    //        }
    //    }
    //    if (isTouching) Dragging(dragPosition);

    //}

    //private void Dragging(Vector2 dragPosition)
    //{
    //    transform.Translate(dragPosition * Time.deltaTime * 0.1f);
    //}
}
