﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class cameraMenu : MonoBehaviour {

    public GameObject playButton;
    public GameObject avatarButton;

    public GameObject backButton;

    public GameObject map1Button;

    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public int punt;
    public float smooth; // time to reach target
    public float maxSpeed;
    public bool inmove;
    private Vector3 dest;
    private float lastTime;

    private float actualTime;

	// Use this for initialization
	void Start () {
        transform.position = point1.transform.position;
        punt = 0;
        smooth = 0.08f;
        maxSpeed = 10f;
        inmove = false;
        actualTime = 0f;
        lastTime = 0f;

    }
	
	// Update is called once per frame
	void Update () {

        if (punt == 0) // menu
        {
            playButton.SetActive(true);
            avatarButton.SetActive(true);        
            map1Button.SetActive(false);
            backButton.SetActive(false);
        }
        else if (punt == 1) // avatar selection
        {
            playButton.SetActive(true);
            avatarButton.SetActive(false);
            map1Button.SetActive(false);
            backButton.SetActive(true);
        }
        else if (punt == 2) // map selection
        {
            playButton.SetActive(false);
            avatarButton.SetActive(true);
            map1Button.SetActive(true);
            backButton.SetActive(true);
        }

        //punt == 0 TITLE MENU
        if (Input.GetKey(KeyCode.Return) && punt == 0 && !inmove) {
            punt = 1;
            inmove = true;
            dest = point2.transform.position;
            lastTime = actualTime;
        }

        // punt == 1 Select Avatar
        if (Input.GetKey(KeyCode.Return) && punt == 1 && !inmove)
        {
            punt = 2;
            inmove = true;
            dest = point3.transform.position;
            lastTime = actualTime;

        }

        // punt == 2 Select Course
        if (Input.GetKey(KeyCode.Return) && punt == 2 && !inmove)
        {
            punt = 0;
            inmove = true;
            dest = point1.transform.position;
            lastTime = actualTime;

        }

        //moure camera
        if (inmove)
        {
            Vector3 v = new Vector3();
            transform.position = Vector3.SmoothDamp(transform.position,dest , ref v, smooth);
          if (actualTime - lastTime > 1.5f) inmove = false;
        }

        if (Input.GetKey(KeyCode.T)) SceneManager.LoadScene("scena1"); 

            actualTime += Time.deltaTime;
	}

    public void clickPlay()
    {

        punt = 2;
        inmove = true;
        dest = point3.transform.position;
        lastTime = actualTime;
    }
    public void clickAvatar()
    {
        punt = 1;
        inmove = true;
        dest = point2.transform.position;
        lastTime = actualTime;
    }
    public void clickBack()
    {
        punt = 0;
        inmove = true;
        dest = point1.transform.position;
        lastTime = actualTime;
    }
    public void loadLevel(int i)
    {
        if (i == 1) SceneManager.LoadScene("scena1");
    }
}
