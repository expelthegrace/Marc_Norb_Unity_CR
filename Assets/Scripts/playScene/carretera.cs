using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carretera : MonoBehaviour {

    public GameObject cotxe;
    public GameObject van;

    public float freq;
    public float vel;
    public float actualTime;
    public float lastCar;
    public int costat;

    public float Pgas;
    public float Ptunak;

    // Use this for initialization
    void Start () {
        costat = Random.Range(0, 2);
        freq = Random.Range(3f, 5f);
        lastCar = -freq;
        actualTime = 0f;
        vel = Random.Range(0.3f, 0.6f);
        Pgas = 5;
        Ptunak = 5;
    }
	
	// Update is called once per frame
	void Update () {

        // cada X segons fem apareixer un cotxe (freq)
        if (actualTime - lastCar > freq)
        {
            GameObject auto;
            Vector3 inipos;
            if (costat == 0)
            {
                inipos = new Vector3(GetComponent<Collider>().bounds.max.x + 60, GetComponent<Collider>().bounds.max.y, transform.position.z);
                if (Random.Range(0, 100) < 50)
                {
                    auto = Instantiate(van, inipos, Quaternion.Euler(0, 0, 0), GameObject.Find("Cotxes").transform);
                    if (Random.Range(0, 100) < Ptunak) auto.GetComponent<AudioSource>().Play();
                }
                else
                {
                    auto = Instantiate(cotxe, inipos, Quaternion.Euler(0, 0, 0), GameObject.Find("Cotxes").transform);
                    if (Random.Range(0, 100) < Pgas) auto.GetComponent<AudioSource>().Play();
                }

                }
            else
            {
                inipos = new Vector3(GetComponent<Collider>().bounds.min.x - 60, GetComponent<Collider>().bounds.max.y, transform.position.z);
                if (Random.Range(0, 100) < 50)
                {
                    auto = Instantiate(van, inipos, Quaternion.Euler(0, 180, 0), GameObject.Find("Cotxes").transform);
                    if (Random.Range(0, 100) < Ptunak) auto.GetComponent<AudioSource>().Play();
                }
                else
                {
                    auto = Instantiate(cotxe, inipos, Quaternion.Euler(0, 180, 0), GameObject.Find("Cotxes").transform);
                    if (Random.Range(0, 100) < Pgas) auto.GetComponent<AudioSource>().Play();
                }

                }
            
            auto.GetComponent<objMoviment>().vel = vel;
           
            lastCar = actualTime;

        }



        freq = Random.Range(3f, 5f);

        actualTime += Time.deltaTime;
	}
}
