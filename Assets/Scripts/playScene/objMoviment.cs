using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objMoviment : MonoBehaviour {
    private GameObject deleteLimit;
    public float vel;
    private float iniVel;
    private float actualTime;

	// Use this for initialization
	void Start () {
        
        actualTime = 0f;
        deleteLimit = GameObject.Find("deleteLimit");
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(-vel * Time.deltaTime * 65, 0, 0));
        if (Mathf.Abs(transform.position.x) > Mathf.Abs(deleteLimit.transform.position.x)) Destroy(gameObject);

        actualTime += Time.deltaTime;
	}
}
