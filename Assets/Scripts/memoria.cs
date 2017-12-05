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
        carregar();

       // totalcoins = 100;
        //playerSelect = 1; // borrar
      //  best1 = 0;
        if (SceneManager.GetActiveScene().name == "scena1") pantalla = 1; //borrar
        if (SceneManager.GetActiveScene().name == "scena2") pantalla = 2; // borrar, s'assignara des del menu
        
    }
	
    void carregar() // descomprimeix el DataPack que es rep de la memoria
    {
        dataP = saveload.Load();
        totalcoins = dataP.totalcoins;
        playerSelect = dataP.playerSelect;
        avatar2 = dataP.avatar2;
        avatar3 = dataP.avatar3;
        best1 = dataP.best1;
        best2 = dataP.best2;
    
    }

    public void guardar()
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

    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            totalcoins += 10;
            guardar();
        }
        if (Input.GetKey(KeyCode.C))
        {
            saveload.ClearData();
            Debug.Log("data cleared (fitxer eliminat)");
        }
    }

   // s'ha de provar funciona, s'ha de fer que si el document no existeix les variables agafin valors inicials, si existeix pues es carrega
   // tambe es pot ficar un clear
}
