using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modelEnlarge : MonoBehaviour {

    public float scaleF;
	// Use this for initialization
	void Start () {
        scaleF = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter()
    {
        Debug.Log("ensima el ratooon");
        transform.localScale += new Vector3(scaleF, scaleF, scaleF);
    }
    void OnMouseExit()
    {
        transform.localScale -= new Vector3(scaleF, scaleF, scaleF);
    }
}
