using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carretera : MonoBehaviour {

    public GameObject cotxe;

    public float freq;
    public float vel;
    public float actualTime;
    public float lastCar;
	// Use this for initialization
	void Start () {
        freq = Random.Range(2f, 4f);
        lastCar = -freq;
        actualTime = 0f;
        vel = Random.Range(0.4f, 0.7f);
    }
	
	// Update is called once per frame
	void Update () {

        // cada X segons fem apareixer un cotxe (freq)
        if (actualTime - lastCar > freq)
        {
            Vector3 inipos = new Vector3(GetComponent<Collider>().bounds.max.x, GetComponent<Collider>().bounds.max.y, transform.position.z);
            GameObject car = Instantiate(cotxe, inipos, Quaternion.Euler(0, 0, 0), GameObject.Find("Cotxes").transform);

            car.GetComponent<cotxeMoviment>().vel = vel;
            lastCar = actualTime;

        }

        actualTime += Time.deltaTime;
	}
}
