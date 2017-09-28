using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObjGlasses : MonoBehaviour {

    public GameObject destroyed;
    public AudioSource glassesAudio;

    private GameObject goDestroy;

    private void OnMouseDown()
    {
        glassesAudio = Instantiate(glassesAudio);
        glassesAudio.Play();
        goDestroy = Instantiate(destroyed, transform.position, Quaternion.identity);
        GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(goDestroy);
        GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(glassesAudio.gameObject);
        Destroy(gameObject);
    }
}
