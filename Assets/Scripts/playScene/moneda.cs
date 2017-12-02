using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneda : MonoBehaviour {
    public float velRot;
    public ParticleSystem particles;
	// Use this for initialization
	void Start () {
        velRot = 0.7f;
        particles.Stop();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, velRot, 0);
	}

    void OnDestroy()
    {
        Instantiate(particles,transform.position + new Vector3 (0,3,0),particles.transform.rotation,GameObject.Find("Monedes").transform);
    }
}
