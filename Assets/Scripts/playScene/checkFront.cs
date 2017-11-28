using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkFront : MonoBehaviour {

    public GameObject player;
    public bool wall;

	// Use this for initialization
	void Start () {
        wall = false;
        
	}
	

    void OnTriggerStay(Collider col)
    {
        if (col.GetComponent<Collider>().tag == "wall")
        {
            player.GetComponent<PlayerMove>().wall = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.GetComponent<Collider>().tag == "wall")
        {
            player.GetComponent<PlayerMove>().wall = false;
        }
    }
}
