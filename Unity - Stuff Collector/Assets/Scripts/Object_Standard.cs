using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Standard : Object_ {

    // Update is called once per frame
    void Update () {
        Move();
        End();
	}

    private void OnMouseDown()
    {
        Destroy(this.gameObject);
        numberDestoyed++;
    }

 }
