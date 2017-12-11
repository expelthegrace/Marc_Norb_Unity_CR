using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class water : MonoBehaviour {

    public GameObject pont;
    private GameObject spawner;
    public float freq;
    public float vel;
    public float actualTime;
    public float lastPont;
    private float step;
    public int costat;
    public float delay;
    public float speedup;

    public float amplitude;
    public float speed;
    private float Yini;
    private float offset;

    private List<GameObject> ponts;

    // Use this for initialization
    void Start () {

        if (SceneManager.GetActiveScene().name != "scenaMenu1") costat = GameObject.Find("Spawner").GetComponent<spawner>().waterCostat;
        else costat = Random.Range(0, 2);
        //costat = Random.Range(0, 2);
        delay = Random.Range(0f, 1f);
        lastPont = delay;
        actualTime = 0f;
        vel = Random.Range(0.3f, 0.4f);
        step = 12;
        ponts = new List<GameObject>();
        speedup = 0f;
        speed = 0.3f;
        amplitude = 1f;
        Yini = 0;

    }
	
	// Update is called once per frame
	void Update () {
        if (actualTime < 2) speedup = 25f;
        else if (speedup == 25)
        {
            for (int i = 0; i < ponts.Count; ++i)
            {
                if (ponts[i] != null) ponts[i].GetComponent<objMoviment>().vel /= speedup;

            }
            speedup = 1f;
        }

        if (actualTime - lastPont > freq)
        {
            freq = Random.Range(3.5f / speedup, 4.5f / speedup);
            Vector3 inipos;
            if (costat == 0) inipos = new Vector3(GetComponent<Collider>().bounds.max.x, GetComponent<Collider>().bounds.max.y-0.2f, transform.position.z+ step/4); // dreta
            else inipos = new Vector3(GetComponent<Collider>().bounds.min.x, GetComponent<Collider>().bounds.max.y-0.2f, transform.position.z + step / 4); //esquerra

            GameObject puente = Instantiate(pont, inipos, Quaternion.Euler(0, 0, 0), GameObject.Find("Ponts").transform);

            if (costat == 0) puente.GetComponent<objMoviment>().vel = vel * speedup;
            else puente.GetComponent<objMoviment>().vel = -vel * speedup;

            lastPont = actualTime;

            ponts.Add(puente);
            

        }

        // moure aigua
        offset = Yini + amplitude * Mathf.Sin(speed * actualTime);
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offset, 0f);
        actualTime += Time.deltaTime;
    }
}
