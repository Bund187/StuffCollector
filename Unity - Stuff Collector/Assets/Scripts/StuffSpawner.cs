using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffSpawner : MonoBehaviour {

    public GameObject[] objetos= new GameObject[9];
    public GameObject[] prefab= new GameObject[6];

    private int randomQuantity = 20;

    void Update () {

        ObjectSpawner();
        if(randomQuantity <= 0)
        {
            randomQuantity = 1;
        }
    }

    private void ObjectSpawner()
    {
        int spawnObj = Random.Range(0, RandomQuantity);
        int objectType = Random.Range(0, 100);

        if (spawnObj == 0)
        {
            int repeatedI=-1;
            int i = Random.Range(0, 9);

            if (repeatedI!=i){
                repeatedI = i;
                if(objectType<95)
                    Instantiate(prefab[0], new Vector2(objetos[i].transform.position.x, objetos[i].transform.position.y+1) , Quaternion.identity);
                else if (objectType < 99 && objectType > 75)
                    Instantiate(prefab[1], new Vector2(objetos[i].transform.position.x, objetos[i].transform.position.y + 1), Quaternion.identity);
                else
                    Instantiate(prefab[2], new Vector2(objetos[i].transform.position.x, objetos[i].transform.position.y + 1), Quaternion.identity);
            }

        }
    }

    public int RandomQuantity
    {
        get
        {
            return randomQuantity;
        }

        set
        {
            randomQuantity = value;
        }
    }
}
