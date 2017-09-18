using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalHeartAnimation : MonoBehaviour {

    float decrease,green,red,alpha;
    GameObject heartDestiny;

    void Start () {
        decrease = transform.localScale.x;
        green = GetComponent<SpriteRenderer>().color.g;
        red = GetComponent<SpriteRenderer>().color.r;
        alpha = GetComponent<SpriteRenderer>().color.a;
    }
	
	// Update is called once per frame
	void Update () {

        transform.position = Vector2.MoveTowards(transform.position, heartDestiny.transform.position, Time.deltaTime*2);
        if (transform.localScale.x > heartDestiny.transform.lossyScale.x)
        {
            decrease -= 0.5f;
            if (GetComponent<SpriteRenderer>().color != heartDestiny.GetComponent<SpriteRenderer>().color)
            {
                green+=0.02f;
                red+=0.02f;
                alpha += 0.02f;
                GetComponent<SpriteRenderer>().color = new Color(red, green, GetComponent<SpriteRenderer>().color.b,alpha);
            }
            transform.localScale = new Vector2(decrease, decrease);
        }
        else
        {
            Destroy(gameObject);
        }
	}

    public GameObject HeartDestiny
    {
        get
        {
            return heartDestiny;
        }

        set
        {
            heartDestiny = value;
        }
    }
}
