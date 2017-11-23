﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;
    public float smoothTime;
    private Vector3 velSmooth;
    public float limitZ;
    public float velNivell;
    private Vector3 nextPos;
    public float limitZIni;

	// Use this for initialization
	void Start () {
    
        offset = transform.position - player.transform.position;
        smoothTime = 0.3f;
        velNivell = 1f;
        limitZIni = transform.position.z;
        limitZ = transform.position.z;
    }
    
	void Reset()
    {
        transform.position = player.transform.position + offset - new Vector3(0, player.transform.position.y, 0);
        limitZ = limitZIni;
    }
	// Update is called once per frame
	void Update () {
        nextPos = Vector3.SmoothDamp(transform.position, player.transform.position + offset - new Vector3(0, player.transform.position.y, 0), ref velSmooth, smoothTime);
        transform.position = new Vector3(nextPos.x, nextPos.y, Mathf.Max(nextPos.z, limitZ));

        limitZ = Mathf.Max(limitZ + velNivell * 0.1f,transform.position.z);

        if (player.GetComponent<PlayerMove>().mort == true)
        {
            Debug.Log("reset camera");  
            Reset();
            player.GetComponent<PlayerMove>().mort = false;
        }
	}
}
