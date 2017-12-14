using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modelEnlarge : MonoBehaviour {
    public GameObject cameraMenu;
    public float scaleF;
    private GameObject pipA;
    // Use this for initialization
    void Start () {
        scaleF = 0.5f;
        pipA = GameObject.Find("pipA");
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter()
    {
        if (cameraMenu.GetComponent<cameraMenu>().punt == 1 || cameraMenu.GetComponent<cameraMenu>().punt == 2)  pipA.GetComponent<AudioSource>().Play();
        transform.localScale += new Vector3(scaleF, scaleF, scaleF);
    }
    void OnMouseExit()
    {
        transform.localScale -= new Vector3(scaleF, scaleF, scaleF);
    }
}
