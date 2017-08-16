using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffSpawner : MonoBehaviour {

    public GameObject[] objetos= new GameObject[9];
    public GameObject[] prefab= new GameObject[6];

    private int randomQuantity = 30;

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

                //Line for the standard Objects
                if (objectType<35) 
                    Instantiate(prefab[0], new Vector2(objetos[i].transform.position.x, objetos[i].transform.position.y+1) , Quaternion.identity);
                //Line for the Diamonds
                else if (objectType < 79 && objectType >= 55)
                    Instantiate(prefab[1], new Vector2(objetos[i].transform.position.x, objetos[i].transform.position.y + 1), Quaternion.identity);
                //Line for the Uraniums
                else if (objectType < 89 && objectType >= 79)
                    Instantiate(prefab[3], new Vector2(objetos[i].transform.position.x, objetos[i].transform.position.y + 1), Quaternion.identity);
                //Line for the Bombs
                else if (objectType < 55 && objectType >= 35)
                    Instantiate(prefab[4], new Vector2(objetos[i].transform.position.x, objetos[i].transform.position.y + 1), Quaternion.identity);
                //Line for the Weights
                else if (objectType < 99 && objectType >= 89)
                    Instantiate(prefab[5], new Vector2(objetos[i].transform.position.x, objetos[i].transform.position.y + 1), Quaternion.identity);
                //Line for the Stars
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
