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
        Vector3 inipos;
        
        for (int i = 0; i < 46; ++i)
        {
            inipos = new Vector3(index + i * (step*0.95f), GetComponent<Collider>().bounds.max.y, transform.position.z);
            Instantiate(rails, inipos, Quaternion.Euler(0,90, 0), GameObject.Find("Rails").transform);           
        }

        float delay = Random.Range(1f, 4f);
        lastTren = delay;
        actualTime = 0f;
        vel = 2.8f;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (actualTime - lastTren > freq)
        {
            GameObject puente;
            freq = Random.Range(5f, 6f);
            Vector3 inipos;
            if (costat == 0) // dreta
            {
                inipos = new Vector3(GetComponent<Collider>().bounds.max.x, GetComponent<Collider>().bounds.max.y, transform.position.z);
                puente = Instantiate(tren, inipos, Quaternion.Euler(0, 180, 0), GameObject.Find("Vies").transform);

            }
            else
            {
                inipos = new Vector3(GetComponent<Collider>().bounds.min.x - step * 15, GetComponent<Collider>().bounds.max.y, transform.position.z);
                puente = Instantiate(tren, inipos, Quaternion.Euler(0, 0, 0), GameObject.Find("Vies").transform);
            }

            puente.GetComponent<objMoviment>().vel = -vel;
            
            lastTren = actualTime;

        }

        actualTime += Time.deltaTime;
    }
}
