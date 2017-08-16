using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageBehaviour : MonoBehaviour {

	private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Uranium"))
        {
            Object_.numberDestoyed++;
            Destroy(collision.gameObject);
        }
    }
}
