using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class via : MonoBehaviour {
    public GameObject tren;
    public GameObject rails;
    public GameObject palote;



    public float freq;
    public float vel;
    public float actualTime;
    public float lastTren;
    public float lastPals;
    private float step;
    private int costat;

    private bool activarpals;

    private float esquerraPals;
    private List<GameObject> palotes;


    private float index;
    // Use this for initialization
    void Start () {
        activarpals = false;
        esquerraPals = GetComponent<Collider>().bounds.min.x; // comença a spawnejar palotes per l'esquerra
        costat = Random.Range(0, 2);
        step = 12f;

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
        if (SceneManager.GetActiveScene().name == "scena3") vel = 6f;
        else vel = 3f;

        float gap = 80f;
        palotes = new List<GameObject>();
        // spawnejar pals
        for (int i = 0; i < GetComponent<Collider>().bounds.size.x / gap; ++i)
        {
            Vector3 inipal = new Vector3(esquerraPals + i * gap, transform.position.y, GetComponent<Collider>().bounds.min.z - 1f);
            GameObject p = Instantiate(palote, inipal, Quaternion.Euler(0, 0, 0), GameObject.Find("Rails").transform);
            palotes.Add(p);
        }
    }
	
	// Update is called once per frame
	void Update () {
       if (!activarpals && actualTime - lastTren > freq - 0.5f)
        {
            lastPals = actualTime;
            activarpals = true;
            for (int i = 0; i < palotes.Count; ++i)
            {
                if (palotes[i] != null)
                {
                    if (SceneManager.GetActiveScene().name != "scenaMenu1") palotes[i].GetComponent<Try>().alarmA.Play();
                    palotes[i].GetComponent<Try>().canGo = false; //no es pot passar, activar red alarm
                }
            }
        }

        else if (activarpals && actualTime - lastPals > 3.5f)
        {

            activarpals = false;
            for (int i = 0; i < palotes.Count; ++i)
            {
                if (palotes[i] != null)
                {
                    if (SceneManager.GetActiveScene().name != "scenaMenu1") palotes[i].GetComponent<Try>().alarmA.Stop();
                    palotes[i].GetComponent<Try>().canGo = true; //no es pot passar, activar red alarm
                }
            }
        }

        if (actualTime - lastTren > freq)
        {
            GameObject puente;
            freq = Random.Range(5f, 7f);
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
