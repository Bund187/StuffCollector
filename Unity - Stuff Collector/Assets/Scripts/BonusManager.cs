using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour {

    List<GameObject> gos = new List<GameObject>();
    List<GameObject> gosBonus = new List<GameObject>();
    int j = 0;
    float timeStart, timeFinal;

    void Update()
    {
        timeFinal = Time.time;
        Timer();
    }

    public void Manager()
    {
        timeStart = Time.time;
        print("TimeStart=" + timeStart);
        
        //Impedimos que se sigan creando nuevos objetos
        GameObject.Find("RealSpawner").GetComponent<StuffSpawner>().NoSpawn = true;

        //Recorremos los objetos con tag bomb y stuff y los añadimos al list
        foreach (GameObject bombs in GameObject.FindGameObjectsWithTag("Bomb"))
        {
            gos.Add(bombs);
        }
        foreach(GameObject stuff in GameObject.FindGameObjectsWithTag("Stuff"))
        {
            gos.Add(stuff);
        }
      
        print("First gos number " + gos.Count);
        //Si el list contiene algo
        if (gos.Count > 0)
        {
            for (int i = 0; i < gos.Count; i++)
            {
                //Recorremos el list y borramos todos aquellos que esten fuera de la pantalla
                if (gos[i].transform.position.y >= GameObject.Find("RealSpawner").GetComponent<StuffSpawner>().objetos[0].transform.position.y)
                {
                    Destroy(gos[i]);
                    gos.RemoveAt(i);
                }
                //Vamos instanciando los objetos de bonus en la posicion de los objetos del list y ponemos estos como no activos (para luego activarlos)
                Instantiate(GameObject.Find("RealSpawner").GetComponent<StuffSpawner>().prefab[6], gos[i].transform.position, Quaternion.identity);
                gos[i].SetActive(false);
                j++;
                
            }
        }
        print("Final gos number " + gos.Count + "Stuff number: " + j);
    }

    public void Timer()
    {
        if (Input.GetKeyDown(KeyCode.A) /*timeFinal >= (timeStart + 3)*/)
        {
            //Recorremos todos los objetos Bonus y los metemos en un List
            foreach (GameObject stuff in GameObject.FindGameObjectsWithTag("Bonus"))
            {
                gosBonus.Add(stuff);
                Destroy(stuff);
            }

            //Recorremos el list con los objetos desactivados y el list de Bonus
            for (int i = 0; i < gos.Count; i++)
            {
                for (int j = 0; j < gosBonus.Count; j++)
                {
                    //Si el objeto desactivado tiene la misma posicion que el objeto de bonus lo activamos haciendolo aparecer en pantalla y lo eliminamos del list
                    if (gos[i].transform.position == gosBonus[j].transform.position)
                    {
                        gos[i].SetActive(true);
                        gos.RemoveAt(i);
                    }
                }
            }
            //Recorremos el list con los objetos que nos quedaban los cuales son los eliminados
            foreach (GameObject stuff in gos)
            {
                Destroy(stuff);
            }
            GameObject.Find("RealSpawner").GetComponent<StuffSpawner>().NoSpawn = false;
        }
    }
}
