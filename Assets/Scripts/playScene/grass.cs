using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grass : MonoBehaviour {

    public GameObject arbre;
    public GameObject tronc;
    public GameObject moneda;
    public float step;
    private float index;
    public bool isIni;

    // Use this for initialization
    void Start()
    {
        step = GameObject.Find("player").GetComponent<PlayerMove>().step;
        index = GetComponent<Collider>().bounds.min.x; // començo per l'esquerra
        Vector3 inipos;

        for (int i = 0; i < GetComponent<Collider>().bounds.size.x / step + 1; ++i)
        {
            if (!isIni || ((index + i * step) / step) != 0)
            {

                if (Random.Range(0, 100) < 22)  // aparicio d'arbres en %
                {
                    inipos = new Vector3(index + i * step, GetComponent<Collider>().bounds.max.y, transform.position.z);
                    if (Random.Range(0, 100) < 70) Instantiate(arbre, inipos, Quaternion.Euler(0, 0, 0), GameObject.Find("Arbres").transform);
                    else Instantiate(tronc, inipos, Quaternion.Euler(0, 0, 0), GameObject.Find("Arbres").transform);
                }
                else if (Random.Range(0, 100) < 3)
                {
                    inipos = new Vector3(index + i * step, GetComponent<Collider>().bounds.max.y, transform.position.z);
                    Instantiate(moneda, inipos, Quaternion.Euler(0, 0, 0), GameObject.Find("Monedes").transform);
                }
            }
            else Debug.Log("salvens");
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
