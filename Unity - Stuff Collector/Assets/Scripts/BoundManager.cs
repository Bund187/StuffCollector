using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundManager : MonoBehaviour {


    public void OnTriggerEnter2D(Collider2D collision)
    {
        print("entra colision=" + collision.gameObject.name);
        if (collision.gameObject.tag.Equals("Bonus"))
        {
            print("entra colision por lo tanto movemos=" + collision.gameObject.name);
            collision.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y + 1);
            //Destroy(collision.gameObject);
        }
    }

}
