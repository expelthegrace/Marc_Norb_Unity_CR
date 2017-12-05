using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roca : MonoBehaviour {
    public float speed;
    public bool enfonsar;
	// Use this for initialization
	void Start () {
        speed = 0.01f;
        enfonsar = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (enfonsar) transform.position = transform.position + new Vector3(0, -speed, 0);

	}
    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player") enfonsar = true;

    }
}
