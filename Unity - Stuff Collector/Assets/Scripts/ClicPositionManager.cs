using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicPositionManager : MonoBehaviour {

    public GameObject brokenScreen;
    public GameObject garbage;

    bool isGameOver;
    GameObject toDestroy;

    void FixedUpdate () {
        if (!isGameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 screenPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D rayHit = Physics2D.Raycast(screenPoint, Vector2.zero);

                if (rayHit.collider == null)
                {
                    this.GetComponent<AudioSource>().Play();
                    toDestroy = Instantiate(brokenScreen, screenPoint, Quaternion.identity);
                    garbage.GetComponent<GarbageManager>().ToDestroy.Add(toDestroy);
                }
            }
        }
    }

    public bool IsGameOver
    {
        get
        {
            return isGameOver;
        }

        set
        {
            isGameOver = value;
        }
    }
}
