using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObjDisk : MonoBehaviour {

    public GameObject destroyedDisk;
    public AudioSource diskAudio;

    private GameObject goDestroy;

    private void OnMouseDown()
    {
        diskAudio = Instantiate(diskAudio);
        diskAudio.Play();
        Destroy(gameObject);
        goDestroy = Instantiate(destroyedDisk, transform.position, Quaternion.identity);
        GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(goDestroy);
        GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(diskAudio.gameObject);
    }
}
