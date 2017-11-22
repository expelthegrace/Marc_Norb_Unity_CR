using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cotxeMoviment : MonoBehaviour {
    private GameObject deleteLimit;
    public float vel;
    private float actualTime;

	// Use this for initialization
	void Start () {
        actualTime = 0f;
        deleteLimit = GameObject.Find("deleteLimit");
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(-vel, 0, 0));
        if (transform.position.x < deleteLimit.transform.position.x) Destroy(gameObject);

        actualTime += Time.deltaTime;
	}
}
