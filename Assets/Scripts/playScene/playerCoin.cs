using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCoin : MonoBehaviour {

    public int coins;

	// Use this for initialization
	void Start () {
        coins = 0;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "moneda")
        {
            Destroy(col.gameObject);
            coins += 1;
        }
       
    }
}
