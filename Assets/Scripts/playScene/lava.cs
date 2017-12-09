using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour {
    public GameObject roca;
    private float index;

    public float speed;
    private float Yini;
    private float offset;
    private float actualTime;
    // Use this for initialization
    void Start () {
        Yini = 0f;
        speed = 0.1f;

        index = GetComponent<Collider>().bounds.min.x; // començo per l'esquerra
        Vector3 inipos;

        for (int i = 0; i < GetComponent<Collider>().bounds.size.x / 12 + 4; ++i)
        {


            if (Random.Range(0, 100) < 55)  // aparicio d'arbres en %
            {
                float rot = Random.Range(0, 180);
                inipos = new Vector3(index + i * 12, GetComponent<Collider>().bounds.max.y - 1.2f, transform.position.z);
                Instantiate(roca, inipos, Quaternion.Euler(0, rot, 0), GameObject.Find("Roques").transform);
            }
            
        }
    }
	
	// Update is called once per frame
	void Update () {



        // moure lava 
        offset = Yini + speed * actualTime;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offset, 0f);
        actualTime += Time.deltaTime;
    }
}
