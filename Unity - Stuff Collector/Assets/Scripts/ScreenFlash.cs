using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFlash : MonoBehaviour {

    public GameObject staticFrame;

    private bool isFlashing;

    void Update()
    {
        if (isFlashing)
        {
            StartCoroutine(ShowStaticFrame());
        }
    }

    IEnumerator ShowStaticFrame()
    {
        staticFrame.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        isFlashing = false;
        staticFrame.SetActive(false);
    }

    public bool IsFlashing
    {
        get
        {
            return isFlashing;
        }

        set
        {
            isFlashing = value;
        }
    }
}
