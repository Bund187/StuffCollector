using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Object_ : MonoBehaviour {

    public static int numberDestoyed = 0;
    public static float speed = 1;

    GameObject instantiateScore;

    protected string textScore;
    
    public virtual void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
    public virtual void End()
    {
        if (transform.position.y < -5)
        {
            if (GameObject.Find("BonusManager").GetComponent<BonusManager>().HeartCounter < 0)
            {
                GameObject.Find("RealSpawner").GetComponent<StuffSpawner>().NoSpawn = false;
                GameObject.Find("TheEnd").GetComponent<EndManager>().IsEnd=true;
                
            }
            else
            {
                GameObject.Find("ShakeScreen").GetComponent<ShakeScreenController>().Shaker();
                GameObject.Find("BonusManager").GetComponent<BonusManager>().BonusLoosing();
            }
            Destroy(this.gameObject);
        }
    }

    protected void ScoreStuff(GameObject obj)
    {
        //obj.GetComponent<StuffScoreController>().ScoreText = textScore;
        print("text scrore is: " + textScore);
        instantiateScore =  Instantiate(obj, new Vector2(transform.position.x + 0.35f, transform.position.y + 0.15f), Quaternion.identity);
        instantiateScore.GetComponent<StuffScoreController>().ScoreText = textScore;
    }
    //protected IEnumerator WaitXseconds()
    //{
    //    Destroy(gameObject);
    //    yield return new WaitForSeconds(1);
    //    End();

    //}

    //public virtual void Touch()
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        Touch touch = Input.GetTouch(0);

    //        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
    //        RaycastHit2D raycastHit = Physics2D.Raycast(worldPoint, Vector2.zero);
    //        if (raycastHit.collider != null)
    //        {
    //            if (raycastHit.collider.name.Equals(this.gameObject.name))
    //            {
    //                if (/*touch.phase == TouchPhase.Stationary || */touch.phase == TouchPhase.Began)
    //                {
    //                    TouchAction();
    //                }
    //            }
    //        }
    //    }
    //}

    //protected abstract void TouchAction();

}
