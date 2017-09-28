using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidManager : MonoBehaviour {


    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void Update()
    {
        BackButton();
    }

    public void BackButton()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
            activity.Call<bool>("moveTaskToBack", true);
        }
    }
}
