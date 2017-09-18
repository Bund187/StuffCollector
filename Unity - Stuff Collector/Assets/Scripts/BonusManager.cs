using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour {

    List<GameObject> gos = new List<GameObject>();
    List<GameObject> gosBonus = new List<GameObject>();
    float timeStart, timeFinal;
    int heartCounter, bonusDestroyed;
    bool isManagerOn;
    GameObject auxiliarHeart;

    public GameObject[] hearts = new GameObject[3];
    public GameObject heartAnimation;
    public AudioSource winHeartAudio;

    private void Start()
    {
        bonusDestroyed = 0;
        heartCounter = -1;
    }
    void Update()
    {
        timeFinal = Time.time;
        if(isManagerOn)
            Timer();
    }

    public void BonusReached()
    {
        //print("bonusdestroyed=" + bonusDestroyed + " gos Count" + gos.Count);
        if (bonusDestroyed == gos.Count)
        {
            winHeartAudio.Play();
            if (heartCounter < 2)
            {
                heartCounter++;
                auxiliarHeart = Instantiate(heartAnimation, new Vector2(0,-4), Quaternion.identity);
                auxiliarHeart.GetComponent<MetalHeartAnimation>().HeartDestiny = hearts[heartCounter];
                hearts[heartCounter].SetActive(true);
                bonusDestroyed = 0;
                print("Add heart nº" + heartCounter + " nombre= " + hearts[heartCounter].name);
            }
           
        }
    }

    public void BonusLoosing()
    {
        
        if (heartCounter>=0)
        {
            print("loosing the heart nº" + heartCounter);
            hearts[heartCounter].SetActive(false);
            heartCounter--;
        }
    }

    public void Manager()
    {
        timeStart = Time.time;
        
        //Impedimos que se sigan creando nuevos objetos
        GameObject.Find("RealSpawner").GetComponent<StuffSpawner>().NoSpawn = true;
        
        //Recorremos los objetos con tag bomb y stuff y los añadimos al list
        gos=Utils.AddObjToList(GameObject.FindGameObjectsWithTag("Bomb"),gos);
        gos=Utils.AddObjToList(GameObject.FindGameObjectsWithTag("Stuff"),gos);

        //Destruimos los objetos especiales
        Utils.DestroyObjFromArray(GameObject.FindGameObjectsWithTag("Uranium"));
        
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
            }

            //Vamos instanciando los objetos de bonus en la posicion de los objetos del list y ponemos estos como no activos (para luego activarlos)
            foreach (GameObject obj in gos)
            {
                Instantiate(GameObject.Find("RealSpawner").GetComponent<StuffSpawner>().prefab[6], obj.transform.position, Quaternion.identity);
                obj.SetActive(false);
                
            }
        }
        //Borramos los posibles bonus que se hayan instanciado fuera de la pantalla
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Bonus").Length-1 ; i++)
        {
            if (gos[i].transform.position.y >= GameObject.Find("RealSpawner").GetComponent<StuffSpawner>().objetos[0].transform.position.y)
            {
                Destroy(gos[i]);
                gos.RemoveAt(i);
            }
        }
        print("Cantidad de objetos a destruir=" + gos.Count);
    }

    public void Timer()
    {
        if (timeFinal >= (timeStart + 3))
        {
            bonusDestroyed = 0;

            //Recorremos todos los objetos Bonus y los metemos en un List a la vez que los eliminamos de pantalla
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
            
            gos.Clear();
            gosBonus.Clear();
            GameObject.Find("RealSpawner").GetComponent<StuffSpawner>().NoSpawn = false;
            isManagerOn = false;
            
        }
    }

    public int BonusDestroyed
    {
        get
        {
            return bonusDestroyed;
        }

        set
        {
            bonusDestroyed = value;
        }
    }

    public int HeartCounter
    {
        get
        {
            return heartCounter;
        }

        set
        {
            heartCounter = value;
        }
    }

    public bool IsManagerOn
    {
        get
        {
            return isManagerOn;
        }

        set
        {
            isManagerOn = value;
        }
    }
}
