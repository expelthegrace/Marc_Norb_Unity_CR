using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {
    public GameObject player;
    public GameObject grass1;
    public GameObject water;
    public GameObject carretera1;
    public GameObject viaa;
    public GameObject lava;
    public GameObject bestObj;

    private GameObject memoria;

    private int lastChunk;

    public float step;
    public int altern;

    public float linea;
    public int chunkLinea;
    private GameObject g;

   // private Bounds playerBox;

    void Spawn()
    {
        if (memoria.GetComponent<memoria>().pantalla == 1) // pantalla 1
        {
            lastChunk = altern;
            switch (altern)
            {
                case 0:
                    g = Instantiate(grass1, new Vector3(0, 0, linea), grass1.transform.rotation, transform);
                    if (chunkLinea == 0) g.GetComponent<grass>().isIni = true;
                    else g.GetComponent<grass>().isIni = false;
                    break;
                case 1:
                    Instantiate(carretera1, new Vector3(0, 0, linea), carretera1.transform.rotation, transform);
                    break;
                case 2:
                    Instantiate(viaa, new Vector3(0, 0, linea), viaa.transform.rotation, transform);
                    break;
                case 3:
                    Instantiate(water, new Vector3(0, -0.62f, linea), water.transform.rotation, transform);

                    break;
            }
            // ficar el best
            if (memoria.GetComponent<memoria>().best1 > 0 && memoria.GetComponent<memoria>().best1 == chunkLinea)
            {

                Instantiate(bestObj, new Vector3(0, 8, linea), bestObj.transform.rotation, transform);

            }


            int r = Random.Range(0, 120);

            if (r > 100) altern = lastChunk;
            else if (r < Mathf.Max(120 - chunkLinea * 3.2f, 40)) altern = 0; // grass
            else if (r < 58) altern = 2; // tren
            else if (r < 82) altern = 3; // water     
            else altern = 1; // road
            
            linea += step;
            chunkLinea = (int)linea / (int)step;
        }
        else if (memoria.GetComponent<memoria>().pantalla == 2) // pantalla 2 amb lava
        {
            lastChunk = altern;
            switch (altern)
            {
                case 0:
                    g = Instantiate(grass1, new Vector3(0, 0, linea), grass1.transform.rotation, transform);
                    if (chunkLinea == 0) g.GetComponent<grass>().isIni = true;
                    else g.GetComponent<grass>().isIni = false;
                    break;
                case 1:
                    Instantiate(carretera1, new Vector3(0, 0, linea), carretera1.transform.rotation, transform);
                    break;
                case 2:
                    Instantiate(viaa, new Vector3(0, 0, linea), viaa.transform.rotation, transform);
                    break;
                case 3:
                    Instantiate(water, new Vector3(0, -0.62f, linea), water.transform.rotation, transform);
                    break;
                case 4:
                    Instantiate(lava, new Vector3(0, -0.7f, linea), lava.transform.rotation, transform);
                    break;
            }
            // ficar el best
            if (memoria.GetComponent<memoria>().best2 > 0 && memoria.GetComponent<memoria>().best2 == chunkLinea)
            {

                Instantiate(bestObj, new Vector3(0, 8, linea), bestObj.transform.rotation, transform);

            }

            int r = Random.Range(0, 120);

            if (r > 100) altern = lastChunk;
            else if (r < Mathf.Max(120 - chunkLinea * 3.2f, 40)) altern = 0; // grass
            else if (r < 49) altern = 2; // tren
            else if (r < 58) altern = 4; // lava  
            else if (r < 82) altern = 3; // water            
            else altern = 1; // road
           // altern = 4;
            linea += step;
            chunkLinea = (int)linea / (int)step;
        }

        else if (memoria.GetComponent<memoria>().pantalla == 3) // pantalla 3 amb lava
        {
            lastChunk = altern;
            switch (altern)
            {
                case 0:
                    g = Instantiate(grass1, new Vector3(0, 0, linea), grass1.transform.rotation, transform);
                    if (chunkLinea == 0) g.GetComponent<grass>().isIni = true;
                    else g.GetComponent<grass>().isIni = false;
                    break;
                case 1:
                    Instantiate(carretera1, new Vector3(0, 0, linea), carretera1.transform.rotation, transform);
                    break;
                case 2:
                    Instantiate(viaa, new Vector3(0, 0, linea), viaa.transform.rotation, transform);
                    break;
                case 3:
                    Instantiate(water, new Vector3(0, -0.62f, linea), water.transform.rotation, transform);
                    break;
                case 4:
                    Instantiate(lava, new Vector3(0, -0.7f, linea), lava.transform.rotation, transform);
                    break;
            }
            // ficar el best
            if (memoria.GetComponent<memoria>().best2 > 0 && memoria.GetComponent<memoria>().best2 == chunkLinea)
            {

                Instantiate(bestObj, new Vector3(0, 8, linea), bestObj.transform.rotation, transform);

            }

            int r = Random.Range(0, 120);

            if (r > 100) altern = lastChunk;
            else if (r < Mathf.Max(120 - chunkLinea * 3.2f, 40)) altern = 0; // grass
            else if (r < 49) altern = 2; // tren
            else if (r < 58) altern = 4; // lava  
            else if (r < 82) altern = 3; // water            
            else altern = 1; // road
                             // altern = 4;
            linea += step;
            chunkLinea = (int)linea / (int)step;
        }
    }

    // Use this for initialization
    void Start () {                              /////// START
        memoria = GameObject.Find("Memoria");
        step = 12;
        altern = 0;
       // playerBox = player.GetComponent<Renderer>().bounds;
        linea = player.transform.position.z - step*4;
        Spawn();
      
    }
	
	// Update is called once per frame
	void Update () {
		while (linea - player.transform.position.z < step * 16) Spawn();

	}
}
