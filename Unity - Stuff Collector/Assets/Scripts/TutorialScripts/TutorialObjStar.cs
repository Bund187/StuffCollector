using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObjStar : MonoBehaviour {

    public AudioSource starDestroyAudio;

    private void OnMouseDown()
    {
        starDestroyAudio = Instantiate(starDestroyAudio);
        starDestroyAudio.Play();
        GameObject.Find("GarbageDestroyer").GetComponent<GarbageManager>().ToDestroy.Add(starDestroyAudio.gameObject);
        GameObject.Find("ScreenFlash").GetComponent<ScreenFlash>().IsFlashing = true;
        Destroy(this.gameObject);
    }
}
