using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour{

	public static void DestroyObjFromArray(GameObject[] array)
    {
        foreach (GameObject obj in array)
        {
            Destroy(obj);
        }
    }

    public static List<GameObject> AddObjToList(GameObject[] array, List<GameObject> list)
    {
        foreach (GameObject obj in array)
        {
            list.Add(obj);
        }
        return list;
    }

    public static List<GameObject> FindInLayer()
    {
        GameObject[] gos = FindObjectsOfType<GameObject>();
        List<GameObject> listGos = new List<GameObject>();

        foreach(GameObject go in gos)
        {
            if (go.layer == 8)
            {
                listGos.Add(go);
            }
        }
        return listGos;
    }
}
