using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Diamond : Object_ {

    private int durability=0;

    void Update()
    {
        Move();
        End();
    }

    private void OnMouseDown()
    {
        durability++;
        if (durability >= 3)
        {
            Destroy(this.gameObject);
            numberDestoyed++;
        }
    }

}
