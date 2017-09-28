using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObjSkate : MonoBehaviour {

    public GameObject destroyedSkate;
    public AudioSource skateAudio;

    private GameObject goDestroy;

    private void OnMouseDown()
    {
        skateAudio = Instantiate(skateAudio);
        skateAudio.Play();
        Destroy(this.gameObject);
        goDestroy = Instantiate(destroyedSkate, transform.position, Quaternion.identity);
        GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(goDestroy);
        GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(skateAudio.gameObject);
    }
}
