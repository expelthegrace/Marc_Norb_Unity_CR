using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grass : MonoBehaviour {

    public GameObject arbre;
    public GameObject player;
    public float step;
    private float index;

    // Use this for initialization
    void Start()
    {
        step = player.GetComponent<PlayerMove>().step;
        index = GetComponent<Collider>().bounds.min.x; // començo per l'esquerra
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inipos;
        for (int i = 0; i < GetComponent<Collider>().bounds.size.z / step; ++i)
        {
            inipos = new Vector3(index + i * step / 2, GetComponent<Collider>().bounds.max.y, transform.position.z + step / 2);
            Instantiate(arbre, inipos, Quaternion.Euler(0, 0, 0), GameObject.Find("Arbres").transform);
        }

        // Vector3 inipos = new Vector3(GetComponent<Collider>().bounds.max.x, GetComponent<Collider>().bounds.max.y, transform.position.z);
        //  GameObject car = Instantiate(arbre, inipos, Quaternion.Euler(0, 0, 0), GameObject.Find("Cotxes").transform);
    }
}
