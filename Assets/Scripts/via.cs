using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class via : MonoBehaviour {
    public GameObject tren;
    public GameObject rails;

    public float freq;
    public float vel;
    public float actualTime;
    public float lastTren;
    private float step;

    private int costat;

    private float index;
    // Use this for initialization
    void Start () {

        costat = Random.Range(0, 2);
        step = GameObject.Find("player").GetComponent<PlayerMove>().step;

        index = GetComponent<Collider>().bounds.min.x - step; // començo per l'esquerra
        float ampladaRail = rails.GetComponent<Collider>().bounds.size.x;
        Vector3 inipos;
        
        for (int i = 0; i < 35; ++i)
        {
            inipos = new Vector3(index + i * (step*0.95f), GetComponent<Collider>().bounds.max.y, transform.position.z);
            Instantiate(rails, inipos, Quaternion.Euler(0,90, 0), GameObject.Find("Rails").transform);           
        }

        float delay = Random.Range(1f, 4f);
        lastTren = delay;
        actualTime = 0f;
        vel = 3f;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (actualTime - lastTren > freq)
        {
            freq = Random.Range(5f, 6f);
            Vector3 inipos;
            if (costat == 0) inipos = new Vector3(GetComponent<Collider>().bounds.max.x, GetComponent<Collider>().bounds.max.y, transform.position.z);
            else inipos = new Vector3(GetComponent<Collider>().bounds.min.x, GetComponent<Collider>().bounds.max.y, transform.position.z);

            GameObject puente = Instantiate(tren, inipos, Quaternion.Euler(0, 0, 0), GameObject.Find("Vies").transform);

            if (costat == 0) puente.GetComponent<objMoviment>().vel = vel;
            else puente.GetComponent<objMoviment>().vel = -vel;
            lastTren = actualTime;

        }

        actualTime += Time.deltaTime;
    }
}
