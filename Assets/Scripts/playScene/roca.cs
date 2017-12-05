using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roca : MonoBehaviour {
    public float speedFall;
    public float speedVibrate;
    public bool enfonsar;
    public float amplitude;
    private float actualTime;
    private float Xnext;
    private float Xini;
	// Use this for initialization
	void Start () {
        speedFall = 0.012f;
        enfonsar = false;
        amplitude = 0.1f;
        actualTime = 0f;
        speedVibrate = 22f;
        Xini = transform.position.x;

    }
	
	// Update is called once per frame
	void Update () {
        if (enfonsar)
        {
            transform.position = transform.position + new Vector3(0, -speedFall, 0);
            Xnext = Xini + amplitude * Mathf.Sin(speedVibrate * actualTime);
            transform.position = new Vector3(Xnext, transform.position.y, transform.position.z);
            actualTime += Time.deltaTime;
        }

	}
    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            enfonsar = true;
        }

    }
}
