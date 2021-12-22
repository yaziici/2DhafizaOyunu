using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesKontrol : MonoBehaviour
{
    private static GameObject instance;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject); //geçiþlerde seslerin kaybolmamasý için

        if (instance == null) //Sesler üst üste binmemesi için önceden oluþan objeyi yok etmeyi saðlar.
            instance = gameObject;
        else
            Destroy(gameObject);
    }
}
