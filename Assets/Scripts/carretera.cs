using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carretera : MonoBehaviour {

    public GameObject cotxe;

    public float freq;
    public float vel;
    public float actualTime;
    public float lastCar;
    public int costat;

    // Use this for initialization
    void Start () {
        costat = Random.Range(0, 2);
        freq = Random.Range(2f, 3f);
        lastCar = -freq;
        actualTime = 0f;
        vel = Random.Range(0.5f, 0.7f);
    }
	
	// Update is called once per frame
	void Update () {

        // cada X segons fem apareixer un cotxe (freq)
        if (actualTime - lastCar > freq)
        {
            Vector3 inipos;
            if (costat == 0) inipos = new Vector3(GetComponent<Collider>().bounds.max.x + 60, GetComponent<Collider>().bounds.max.y, transform.position.z);
            else inipos = new Vector3(GetComponent<Collider>().bounds.min.x - 60, GetComponent<Collider>().bounds.max.y, transform.position.z);
            GameObject car = Instantiate(cotxe, inipos, Quaternion.Euler(0, 0, 0), GameObject.Find("Cotxes").transform);

            if (costat == 0) car.GetComponent<objMoviment>().vel = vel;
            else car.GetComponent<objMoviment>().vel = -vel;

            lastCar = actualTime;

        }

        actualTime += Time.deltaTime;
	}
}
