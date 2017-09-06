using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void End()
    {
        print("no active");
        GameObject.Find("RealSpawner").GetComponent<StuffSpawner>().NoSpawn = true;
        List<GameObject> goToDestroy = Utils.FindInLayer();
        foreach (GameObject go in goToDestroy)
        {
            Destroy(go);
        }

    }
}
