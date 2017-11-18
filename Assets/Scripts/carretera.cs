using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carretera : MonoBehaviour {

    public GameObject cotxe;

    public int numCotxes;
    public float freq;
    public float actualTime;
    public float lastCar;
	// Use this for initialization
	void Start () {
        numCotxes = 0;
        freq = 2;
        lastCar = 0;
        actualTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (actualTime - lastCar > freq)
        {
            Vector3 inipos = new Vector3(GetComponent<Collider>().bounds.max.x, GetComponent<Collider>().bounds.max.y, transform.position.z);
            Instantiate(cotxe, inipos, Quaternion.Euler(0, 0, 0), GameObject.Find("Cotxes").transform);
            ++numCotxes;
            lastCar = actualTime;

        }

        actualTime += Time.deltaTime;
	}
}
