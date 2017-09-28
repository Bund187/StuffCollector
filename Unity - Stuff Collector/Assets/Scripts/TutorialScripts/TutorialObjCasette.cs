using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObjCasette : MonoBehaviour {

    public GameObject destroyed;
    public AudioSource destroyedAudio;

    private GameObject goDestroy;

    private void OnMouseDown()
    {
        destroyedAudio = Instantiate(destroyedAudio);
        destroyedAudio.Play();
        Destroy(gameObject);
        goDestroy = Instantiate(destroyed, transform.position, Quaternion.identity);
        GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(goDestroy);
        GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(destroyedAudio.gameObject);
    }
}
