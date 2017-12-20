using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasHTP : MonoBehaviour {
    public GameObject canvasMenu;
    public GameObject cameraMenu;

    private Vector3 offset;
    public bool activarHTP;

    private Vector3 iniPos;
    private Vector3 vel;
    private int lastP;

    // Use this for initialization
    void Start () {
        lastP = 0;
        offset = canvasMenu.transform.position - transform.position;
        activarHTP = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (activarHTP)
        {
            transform.position = canvasMenu.transform.position;
        }
        else 
        {
            transform.position = canvasMenu.transform.position - offset;
        }
    }

    public void activar()
    {
        lastP = cameraMenu.GetComponent<cameraMenu>().punt;
        cameraMenu.GetComponent<cameraMenu>().punt = 3;
        
        activarHTP = true;
    }
    public void desactivar()
    {
        activarHTP = false;
        cameraMenu.GetComponent<cameraMenu>().punt = lastP;
    }
}
