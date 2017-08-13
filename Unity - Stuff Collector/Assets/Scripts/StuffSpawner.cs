using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffSpawner : MonoBehaviour {

    public GameObject[] objetos= new GameObject[9];
    public GameObject prefab;

    public int randomQuantity = 50;

    void Update () {

        //if(GetComponent<ObjectBehaviour>().IsEnd==false)
            ObjectSpawner();
        
    }

    private void ObjectSpawner()
    {
        int spawnObj = Random.Range(0, randomQuantity);

        if (spawnObj == 0)
        {
            int repeatedI=-1;
            int i = Random.Range(0, 9);

            if (repeatedI!=i){
                repeatedI = i;
                GameObject go = Instantiate(prefab, objetos[i].transform.position, Quaternion.identity);
            }

        }
    }
}
