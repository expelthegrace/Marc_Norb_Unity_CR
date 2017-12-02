using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObj : MonoBehaviour {
    public float velRot;
    // Use this for initialization
    void Start () {
        velRot = 0.7f;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, velRot, 0);
    }
}
