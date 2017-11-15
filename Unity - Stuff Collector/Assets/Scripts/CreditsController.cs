using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour {

    public GameObject tapStart, credits;
    public AudioSource creditsAudio;

    private bool on;
	
    private void OnMouseDown()
    {
        creditsAudio.Play();
        on = !on;
        if (on)
        {
            tapStart.SetActive(false);
            credits.SetActive(true);
        }
        else
        {
            tapStart.SetActive(true);
            credits.SetActive(false);
        }
    }
}
