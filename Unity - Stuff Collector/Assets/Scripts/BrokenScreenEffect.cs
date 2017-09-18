using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenScreenEffect : MonoBehaviour {

    public GameObject screenBroken;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Instantiate(screenBroken, Input.mousePosition., Quaternion.identity);
        //}
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Instantiate(screenBroken, Input.GetTouch(0).position, Quaternion.identity);
            //Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            //RaycastHit2D raycastHit = Physics2D.Raycast(worldPoint, Vector2.zero);
            //if (raycastHit.collider != null)
            //{
            //    if (raycastHit.collider.name.Equals(this.gameObject.name))
            //    {
            //        if (/*touch.phase == TouchPhase.Stationary || */touch.phase == TouchPhase.Began)
            //        {
            //            TouchAction();
            //        }
            //    }
            //}
        }
    }


}
