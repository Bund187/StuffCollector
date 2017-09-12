using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StuffScoreController : MonoBehaviour {

    private float alpha, fadeSpeed,speed;
    private bool isfading;
    private string scoreText;

    void Start () {
        //transform.position = new Vector2(s.transform.position.x+0.35f, s.transform.position.y + 0.15f);
        alpha = GetComponent<Text>().color.a;
        fadeSpeed = 0.03f;
        GetComponent<Text>().text = scoreText;
        transform.parent = GameObject.Find("CanvasUpper").transform;
        transform.localScale = new Vector2(1, 1);
        speed = 0.1f;
    }
	
	void Update () {

        GetComponent<Text>().color = new Color(GetComponent<Text>().color.r, GetComponent<Text>().color.g, GetComponent<Text>().color.b, alpha);
        transform.Translate(Vector2.up * (Time.deltaTime*speed));
        if (!isfading)
            FadeIn();
        else
            FadeOut();
    }

    public void FadeOut()
    {
        if (GetComponent<Text>().color.a > 0)
        {
            alpha -= fadeSpeed;
        }
        else
        {
            print("alpha=" + GetComponent<Text>().color.a);
            Destroy(this.gameObject);
        }
       
    }

    public void FadeIn()
    {
        if (GetComponent<Text>().color.a < 1)
        {
            alpha += fadeSpeed;
        }
        else
        {
            
            isfading = true;
        }

    }

    public string ScoreText
    {
        get
        {
            return scoreText;
        }

        set
        {
            scoreText = value;
        }
    }
}
