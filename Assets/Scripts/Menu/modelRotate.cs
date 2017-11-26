using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modelRotate : MonoBehaviour {

    public float velRot;
    public bool rotar;
    public GameObject cameraMenu;

	// Use this for initialization
	void Start () {
        velRot = 0.7f;
        rotar = false;

	}
	
	// Update is called once per frame
	void Update () {
        if (cameraMenu.GetComponent<cameraMenu>().punt == 1) rotar = true;

        if (rotar) transform.Rotate(0, velRot, 0);
	}
}
