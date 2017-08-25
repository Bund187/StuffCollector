using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Weight : Object_ {

    private float ownSpeed;

    private void Start()
    {
        ownSpeed = 3;
    }
    void Update()
    {
        Move();
        End();
    }

    private void OnMouseDown()
    {
        Destroy(this.gameObject);
        numberDestoyed++;
    }

    public override void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * ownSpeed);
    }
}
