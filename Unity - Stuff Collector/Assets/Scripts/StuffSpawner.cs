using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffSpawner : MonoBehaviour {

    public GameObject[] objetos= new GameObject[9];
    public GameObject[] prefab= new GameObject[7];
    public GameObject goGameController;

    private bool noSpawn;
    private int randomQuantity;

    private void Start()
    {
        randomQuantity = 10;
        
    }

    void Update () {

        if(!noSpawn)
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

                float distance = 1.5f;
                if (goGameController.GetComponent<GameController>().LevelNumber >= 1)
                {
                    //Line for the Cassette
                    if (objectType <= 35)
                        Instantiate(prefab[0], new Vector2(objetos[i].transform.position.x, objetos[i].transform.position.y + distance), Quaternion.identity);
                }
                if (goGameController.GetComponent<GameController>().LevelNumber >= 3)
                {
                    randomQuantity = 30;

                    //Line for the TV
                    if (objectType <= 55 && objectType > 35)
                        Instantiate(prefab[1], new Vector2(objetos[i].transform.position.x, objetos[i].transform.position.y + distance), Quaternion.identity);
                }
                
                //Line for the VR
                if (objectType <= 58 && objectType > 55)
                    Instantiate(prefab[3], new Vector2(objetos[i].transform.position.x, objetos[i].transform.position.y + distance), Quaternion.identity);

                //Line for the Bombs
                SpawnBomb(objectType, distance, i);

                if (goGameController.GetComponent<GameController>().LevelNumber >= 5)
                {
                    //Line for the Skate
                    if (objectType <= 96 && objectType > 86)
                        Instantiate(prefab[5], new Vector2(objetos[i].transform.position.x, objetos[i].transform.position.y + distance), Quaternion.identity);
                }
                if (goGameController.GetComponent<GameController>().LevelNumber >= 4)
                {
                    //Line for the Stars
                    if (objectType <= 100 && objectType > 96)
                        Instantiate(prefab[2], new Vector2(objetos[i].transform.position.x, objetos[i].transform.position.y + distance), Quaternion.identity);
                }
            }

        }
    }

    public void SpawnBomb(int objectType, float distance, int i)
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Stuff");

        if (objectType <= 86 && objectType > 58)
            Instantiate(prefab[4], new Vector2(objetos[i].transform.position.x, objetos[i].transform.position.y + distance), Quaternion.identity);
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

    public bool NoSpawn
    {
        get
        {
            return noSpawn;
        }

        set
        {
            noSpawn = value;
        }
    }
}
