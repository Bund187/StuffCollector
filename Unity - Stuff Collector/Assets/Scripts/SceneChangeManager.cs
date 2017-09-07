using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour {

	void Update () {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    print("mouse");
        //    SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        //}
    }

    private void OnMouseDown()
    {
        print("mouse");
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
