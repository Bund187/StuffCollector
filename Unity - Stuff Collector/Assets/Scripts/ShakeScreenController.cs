using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScreenController : MonoBehaviour {

    public GameObject background, frame;

    private bool isShaking;
    private Vector2 startPositionBack, startPositionFrame;

	// Use this for initialization
	void Start () {
        startPositionBack = background.transform.position;
        startPositionFrame = frame.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Shaker()
    {

        isShaking = !isShaking;
        if (isShaking)
        {
            StartCoroutine("Shake");
        }
    }

    IEnumerator Shake()
    {
        background.transform.position = new Vector2(startPositionBack.x + 0.5f, background.transform.position.y);
        frame.transform.position = new Vector2(startPositionFrame.x + 0.5f, frame.transform.position.y);
        yield return new WaitForSeconds(0.05f);
        background.transform.position = new Vector2(startPositionBack.x - 0.2f, background.transform.position.y);
        frame.transform.position = new Vector2(startPositionFrame.x - 0.2f, frame.transform.position.y);
        yield return new WaitForSeconds(0.1f);
        background.transform.position = new Vector2(startPositionBack.x + 0.3f, background.transform.position.y);
        frame.transform.position = new Vector2(startPositionFrame.x + 0.3f, frame.transform.position.y);
        yield return new WaitForSeconds(0.07f);
        background.transform.position = startPositionBack;
        frame.transform.position = startPositionFrame;
        isShaking = false;
    }
}
