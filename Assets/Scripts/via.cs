using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class via : MonoBehaviour {
    public GameObject tren;

    public float freq;
    public float vel;
    public float actualTime;
    public float lastTren;
    private float step;
    // Use this for initialization
    void Start () {
        freq = Random.Range(5f, 6f);
        lastTren = -freq;
        actualTime = 0f;
        vel = 3f;
        step = GameObject.Find("player").GetComponent<PlayerMove>().step;
    }
	
	// Update is called once per frame
	void Update () {
        if (actualTime - lastTren > freq)
        {
            freq = Random.Range(5f, 6f);
            //Vector3 inipos = new Vector3(GetComponent<Collider>().bounds.max.x, GetComponent<Collider>().bounds.max.y, transform.position.z + step / 4);
            Vector3 inipos = new Vector3(GetComponent<Collider>().bounds.max.x, GetComponent<Collider>().bounds.max.y, transform.position.z + step / 4);
            GameObject puente = Instantiate(tren, inipos, Quaternion.Euler(0, 0, 0), GameObject.Find("Vies").transform);

            puente.GetComponent<cotxeMoviment>().vel = vel;
            lastTren = actualTime;

        }

        actualTime += Time.deltaTime;
    }
}
