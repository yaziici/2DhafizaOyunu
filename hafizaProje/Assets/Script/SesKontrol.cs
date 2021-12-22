using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesKontrol : MonoBehaviour
{
    private static GameObject instance;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject); //ge�i�lerde seslerin kaybolmamas� i�in

        if (instance == null) //Sesler �st �ste binmemesi i�in �nceden olu�an objeyi yok etmeyi sa�lar.
            instance = gameObject;
        else
            Destroy(gameObject);
    }
}
