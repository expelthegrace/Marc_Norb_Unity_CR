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
    public float delay;
    public float speedup;

    private List<GameObject> ponts;

    // Use this for initialization
    void Start () {
        costat = Random.Range(0, 2);
        delay = Random.Range(0f, 1f);
        lastPont = delay;
        actualTime = 0f;
        vel = Random.Range(0.18f, 0.28f);
        step = 12;
        ponts = new List<GameObject>();
        speedup = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (actualTime < 2) speedup = 20f;
        else if (speedup == 20)
        {
            Debug.Log("fin");
            for (int i = 0; i < ponts.Count; ++i)
            {
                if (ponts[i] != null) ponts[i].GetComponent<objMoviment>().vel /= speedup;

            }
            speedup = 1f;
        }

        if (actualTime - lastPont > freq)
        {
            freq = Random.Range(3.8f / speedup, 4.5f / speedup);
            Vector3 inipos;
            if (costat == 0) inipos = new Vector3(GetComponent<Collider>().bounds.max.x, GetComponent<Collider>().bounds.max.y-0.4f, transform.position.z+ step/4); // dreta
            else inipos = new Vector3(GetComponent<Collider>().bounds.min.x, GetComponent<Collider>().bounds.max.y-0.4f, transform.position.z + step / 4); //esquerra

            GameObject puente = Instantiate(pont, inipos, Quaternion.Euler(0, 0, 0), GameObject.Find("Ponts").transform);

            if (costat == 0) puente.GetComponent<objMoviment>().vel = vel * speedup;
            else puente.GetComponent<objMoviment>().vel = -vel * speedup;

            lastPont = actualTime;

            ponts.Add(puente);
            

        }



        actualTime += Time.deltaTime;
    }
}
