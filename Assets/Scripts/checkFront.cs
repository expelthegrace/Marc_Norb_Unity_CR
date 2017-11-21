using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkFront : MonoBehaviour {

    public bool wall;

	// Use this for initialization
	void Start () {
        wall = false;
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("colisio checkFront");
        if (col.GetComponent<Collider>().tag == "wall") wall = true;
    }
    void OnTriggerExit(Collider col)
    {
        Debug.Log("surt checkFront");
        wall = false;
    }
}
