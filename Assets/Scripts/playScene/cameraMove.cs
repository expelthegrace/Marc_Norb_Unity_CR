﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class cameraMove : MonoBehaviour {

    public GameObject player;
    public GameObject limitCamera;
    

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
        velNivell = 0.75f; // 0.75
        limitZIni = transform.position.z;
        limitZ = transform.position.z;
    }
    
	
	// Update is called once per frame
	void Update () {
        if (!player.GetComponent<PlayerMove>().mort)
        {
            nextPos = Vector3.SmoothDamp(transform.position, player.transform.position + offset - new Vector3(0, player.transform.position.y, 0), ref velSmooth, smoothTime);
            transform.position = new Vector3(Mathf.Max(Mathf.Min(nextPos.x, limitCamera.transform.position.x), -limitCamera.transform.position.x + 40), nextPos.y, Mathf.Max(nextPos.z, limitZ));

            limitZ = Mathf.Max(limitZ + velNivell * 0.1f * Time.deltaTime * 50, transform.position.z);

            if (Input.GetKey(KeyCode.T)) SceneManager.LoadScene("scenaMenu1"); // borrar
        }
    }
}
