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

       /* if (altern < 50) Instantiate(grass1, new Vector3(0, 0, linea), grass1.transform.rotation,transform);
        else if (altern < 70)  Instantiate(carretera1, new Vector3(0, 0, linea), carretera1.transform.rotation,transform);
        else if (altern < 80) Instantiate(via, new Vector3(0, 0, linea), via.transform.rotation, transform);
        else Instantiate(water, new Vector3(0, -0.62f, linea), water.transform.rotation, transform);*/
        linea += step;
        altern = Random.Range(0, 5);
        if (altern > 3) altern = lastChunk;
        
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
