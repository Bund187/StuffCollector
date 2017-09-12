using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageManager : MonoBehaviour {

    private float seconds, timer;
    private List<GameObject> toDestroy = new List<GameObject>();

    // Use this for initialization
    void Start () {
        
        seconds = 300;
        timer = seconds;
    }
	
	// Update is called once per frame
	void Update () {
        GarbageDestroy();
    }

    private void GarbageDestroy()
    {

        if (timer <= 0)
        {
            if (toDestroy.Count >= 0)
            {
                foreach (GameObject destr in toDestroy)
                {
                    if (destr != null)
                    {
                        if (destr.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !destr.GetComponent<Animator>().IsInTransition(0))
                        {
                            if (GameObject.Find("BonusManager").GetComponent<BonusManager>().HeartCounter < 0)
                            {
                                if (destr.name.Contains("BombExplosion"))
                                {
                                    GameObject.Find("TheEnd").GetComponent<EndManager>().IsEnd=true;
                                }

                            }
                            else
                            {
                                GameObject.Find("BonusManager").GetComponent<BonusManager>().BonusLoosing();
                            }
                            Destroy(destr);
                        }
                    }
                }
            }
            timer = seconds;
           
        }
        else
        {
            timer -= Time.time;
        }
    }

    public List<GameObject> ToDestroy
    {
        get
        {
            return toDestroy;
        }

        set
        {
            toDestroy = value;
        }
    }
}
