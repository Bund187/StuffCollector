using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundManager : MonoBehaviour {

	
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("entra colision=" + collision.gameObject.name);
        Destroy(collision.gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        print("Esta dentro colision=" + collision.gameObject.name);
        Destroy(collision.gameObject);
    }
}
