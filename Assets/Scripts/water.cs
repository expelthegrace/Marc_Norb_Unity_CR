using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour {

    public GameObject pont;

    public float freq;
    public float vel;
    public float actualTime;
    public float lastPont;
    private float step;
    public int costat;

    // Use this for initialization
    void Start () {
        costat = Random.Range(0, 2);
        freq = Random.Range(2.5f, 3f);
        lastPont = -freq;
        actualTime = 0f;
        vel = Random.Range(0.18f, 0.28f);
        step = GameObject.Find("player").GetComponent<PlayerMove>().step;
    }
	
	// Update is called once per frame
	void Update () {
        if (actualTime - lastPont > freq)
        {
            freq = Random.Range(4f, 5f);
            Vector3 inipos;
            if (costat == 0) inipos = new Vector3(GetComponent<Collider>().bounds.max.x, GetComponent<Collider>().bounds.max.y, transform.position.z+ step/4);
            else inipos = new Vector3(GetComponent<Collider>().bounds.min.x, GetComponent<Collider>().bounds.max.y, transform.position.z + step / 4);

            GameObject puente = Instantiate(pont, inipos, Quaternion.Euler(0, 0, 0), GameObject.Find("Ponts").transform);

            if (costat == 0) puente.GetComponent<objMoviment>().vel = vel;
            else puente.GetComponent<objMoviment>().vel = -vel;
            lastPont = actualTime;

        }

        actualTime += Time.deltaTime;
    }
}
