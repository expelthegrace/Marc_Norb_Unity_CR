using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {
    public GameObject player;
    public GameObject grass1;
    public GameObject water;
    public GameObject carretera1;
    public GameObject via;

    private int lastChunk;
    // chunks {GRASS, VIA, AIGUA, ROAD };

    public float step;
    public int altern;

    public float linea;
    public int chunkLinea;

   // private Bounds playerBox;

    void Spawn()
    {
        lastChunk = altern;
        switch (altern)
        {
            case 0:
                Instantiate(grass1, new Vector3(0, 0, linea), grass1.transform.rotation, transform);
                break;
            case 1:
                Instantiate(carretera1, new Vector3(0, 0, linea), carretera1.transform.rotation, transform);
                break;
            case 2:
                Instantiate(via, new Vector3(0, 0, linea), via.transform.rotation, transform);
                break;
            case 3:
                Instantiate(water, new Vector3(0, -0.62f, linea), water.transform.rotation, transform);
                break;
        }
        int r = Random.Range(0, 120);

        if (r > 100) altern = lastChunk;
        else if (r < Mathf.Max(100 - chunkLinea * 2f, 40)) altern = 0; // grass
        else if (r < 58) altern = 2; // tren
        else if (r < 82) altern = 3; // water     
        else altern = 1; // road
       
        linea += step;
        chunkLinea = (int)linea / (int)step;
     
    }

    // Use this for initialization
    void Start () {                              /////// START
        step = 12;
        altern = 0;
       // playerBox = player.GetComponent<Renderer>().bounds;
        linea = player.transform.position.z;
        Spawn();
      
    }
	
	// Update is called once per frame
	void Update () {
		while (linea - player.transform.position.z < step * 15) Spawn();

	}
}
