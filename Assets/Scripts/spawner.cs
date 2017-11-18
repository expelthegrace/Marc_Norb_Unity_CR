using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {
    public GameObject player;
    public GameObject grass1;
    public GameObject grass2;
    

    public float step;
    public int altern;

    public float linea;
   // private Bounds playerBox;

    void Spawn()
    {
        if (altern == 1) Instantiate(grass1, new Vector3(0, 0, linea), grass1.transform.rotation,transform);
        else Instantiate(grass2, new Vector3(0, 0, linea), grass1.transform.rotation,transform);
        linea += step;
        if (altern == 1) altern = 2;
        else altern = 1;
    }

    // Use this for initialization
    void Start () {
        step = 12;
        altern = 1;
       // playerBox = player.GetComponent<Renderer>().bounds;
        linea = player.transform.position.z;
        Spawn();
       
	}
	
	// Update is called once per frame
	void Update () {
		while (linea - player.transform.position.z < step * 4) Spawn();

	}
}
