using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour {

    bool changeScene;

    public GameObject transition;
    public AudioSource theme;

	void Update () {
        if (changeScene)
        {
            transition.SetActive(true);
            //StartCoroutine("FadeoutSound");
            theme.volume -= 0.009f;
            if (theme.volume <= 0)
            {
                SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
            }
        }
    }

    private void OnMouseDown()
    {
        changeScene = true;
    }

    //IEnumerator FadeoutSound()
    //{
    //    while (theme.volume > 0)
    //    {
    //        theme.volume -= 0.1f;
    //        yield return null;
    //    }
    //}
}
