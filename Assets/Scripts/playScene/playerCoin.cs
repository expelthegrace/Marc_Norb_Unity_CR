using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCoin : MonoBehaviour {

    public int contador;

	// Use this for initialization
	void Start () {
        contador = 0;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "moneda")
        {
            Destroy(col.gameObject);
            contador += 1;
        }
       
    }
}
