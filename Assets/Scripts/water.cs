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

    // Use this for initialization
    void Start () {
        
        lastPont = -freq;
        actualTime = 0f;
        vel = Random.Range(0.2f, 0.35f);
        step = GameObject.Find("player").GetComponent<PlayerMove>().step;
    }
	
	// Update is called once per frame
	void Update () {
        if (actualTime - lastPont > freq)
        {
            freq = Random.Range(2.5f, 3f);
            Vector3 inipos = new Vector3(GetComponent<Collider>().bounds.max.x, GetComponent<Collider>().bounds.max.y, transform.position.z+ step/4);
            GameObject puente = Instantiate(pont, inipos, Quaternion.Euler(0, 0, 0), GameObject.Find("Ponts").transform);

            puente.GetComponent<cotxeMoviment>().vel = vel;
            lastPont = actualTime;

        }

        actualTime += Time.deltaTime;
    }
}
