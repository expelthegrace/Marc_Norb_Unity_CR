using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMenu : MonoBehaviour {

    public GameObject point1;
    public GameObject point2;
    public int punt;
    public float smooth; // time to reach target
    public float maxSpeed;
    private bool inmove;

	// Use this for initialization
	void Start () {
        transform.position = point1.transform.position;
        punt = 0;
        smooth = 0.08f;
        maxSpeed = 10f;
        inmove = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Return)) {
            punt = 1;
            inmove = true;
        }

        if (punt == 1 && inmove)
        {
            Vector3 v = new Vector3();
            transform.position = Vector3.SmoothDamp(transform.position, point2.transform.position, ref v, smooth);
            if (transform.position == point2.transform.position) inmove = false;
        }


	}
}
