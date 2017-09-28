using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObjTV : MonoBehaviour {

    private int durability;
    private float startTime;
    private GameObject goDestroy;

    public GameObject brokenTv, destroyedTv;
    public Sprite[] sprites = new Sprite[3];
    public AudioSource[] tvAudio = new AudioSource[6];
    
    private void Update()
    {
        if (Time.time >= startTime + 0.1f)
        {
            brokenTv.SetActive(false);
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[durability];
        }
    }

    private void OnMouseDown()
    {

        int indexAudio = Random.Range(0, 6);
        while (tvAudio[indexAudio] == null)
        {
            indexAudio = Random.Range(0, 6);
        }
        tvAudio[indexAudio] = Instantiate(tvAudio[indexAudio]);
        tvAudio[indexAudio].Play();
        GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(tvAudio[indexAudio].gameObject);
        durability++;

        if (durability >= 3)
        {

            Destroy(this.gameObject);
            goDestroy = Instantiate(destroyedTv, transform.position, Quaternion.identity);
            GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(goDestroy);
        }
        else
        {
            brokenTv.SetActive(true);
            startTime = Time.time;
        }
    }
}
