using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatTitle : MonoBehaviour {
    public float amplitude;
    public float speed;
    public float Yini;
    private float Ynext;

    public float g;
    public float vFall;

    private float actualTime;

    private bool landed;

    public GameObject omegaCenter;
	// Use this for initialization
	void Start () {
        amplitude = 1f;
        speed = 1f;
        
        vFall = 0;
        g = 0.2f;
        landed = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!landed)
        {
            Ynext = transform.position.y - vFall;
            vFall += g;
            Vector3 v = new Vector3();
            // transform.position = new Vector3(transform.position.x, Ynext, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, omegaCenter.transform.position, ref v, 0.12f);
            if (transform.position.y - 1 <= omegaCenter.transform.position.y)
            {
                landed = true;
                Yini = transform.position.y;
                actualTime = 0;
            }
        }
        else 
        {
            Ynext = Yini + amplitude * Mathf.Sin(speed * actualTime);
            transform.position = new Vector3(transform.position.x, Ynext, transform.position.z);
            actualTime += Time.deltaTime;
        }
    }
}
