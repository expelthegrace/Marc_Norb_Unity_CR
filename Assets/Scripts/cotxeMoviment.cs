using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cotxeMoviment : MonoBehaviour {

    public float vel;
    private float actualTime;

	// Use this for initialization
	void Start () {
        actualTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(-vel, 0, 0));
        if (actualTime > 4) Destroy(gameObject);

        actualTime += Time.deltaTime;
	}
}
