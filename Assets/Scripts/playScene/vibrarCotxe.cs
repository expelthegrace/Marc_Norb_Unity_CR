using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vibrarCotxe : MonoBehaviour {
    public float speed;
    public float Yini;
    private float Ynext;
    public float amplitude;

    private float actualTime;
    // Use this for initialization
    void Start () {
        actualTime = 0f;
        amplitude = 0.05f;
        Yini = transform.position.y;
        speed = 60;
	}
	
	// Update is called once per frame
	void Update () {
        Ynext = Yini + amplitude * Mathf.Sin(speed * actualTime);
        transform.position = new Vector3(transform.position.x, Ynext, transform.position.z);
        actualTime += Time.deltaTime;
    }
}
