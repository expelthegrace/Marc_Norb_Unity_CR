using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;


public class memoria : MonoBehaviour {
    DataPack dataP;
    private saveLoad saveload;

    private static memoria instanceRef;
    public int totalcoins;
    public int playerSelect;

    public bool avatar2;
    public bool avatar3;

    public int best1;
    public int best2;
    public int pantalla;


    void Awake()
    {


        if (instanceRef == null)
        {
            instanceRef = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        saveload = GameObject.Find("Memoria").GetComponent<saveLoad>();
        dataP = saveload.Load();

        totalcoins = 100;
        playerSelect = 1; // borrar
        best1 = 0;
        if (SceneManager.GetActiveScene().name == "scena1") pantalla = 1; //borrar
        if (SceneManager.GetActiveScene().name == "scena2") pantalla = 2; // borrar, s'assignara des del menu
    }
	
    void guardar()
    {
        dataP = new DataPack();
        dataP.totalcoins = totalcoins;
        dataP.playerSelect = playerSelect;
        dataP.avatar2 = avatar2;
        dataP.avatar3 = avatar3;
        dataP.best1 = best1;
        dataP.best2 = best2;

        saveload.Save(dataP);

    }

   
}
