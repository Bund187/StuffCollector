using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour {

    public GameObject titleAppear, title;

    void Update ()
    { 
        if (titleAppear.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !titleAppear.GetComponent<Animator>().IsInTransition(0))
        {
            title.SetActive(true);
        }
        if(title.activeSelf==true)
        {
            titleAppear.SetActive(false);
            
        }
    }
    
}
