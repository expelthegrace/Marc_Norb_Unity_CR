using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grass : MonoBehaviour {

    public GameObject arbre;
    public float step;
    private float index;

    // Use this for initialization
    void Start()
    {
        step = GameObject.Find("player").GetComponent<PlayerMove>().step;
        index = GetComponent<Collider>().bounds.min.x + step / 2; // començo per l'esquerra
        Vector3 inipos;
        Debug.Log(index);

        for (int i = 0; i < GetComponent<Collider>().bounds.size.x / step; ++i)
        {
            if (Random.Range(0,100) < 35)
            {

                inipos = new Vector3(index + i * step, GetComponent<Collider>().bounds.max.y, transform.position.z);
                Instantiate(arbre, inipos, Quaternion.Euler(0, 0, 0), GameObject.Find("Arbres").transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
