﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class canvasMenuCs : MonoBehaviour {

    private GameObject memoria;
    public Text totalcoinsT;
    public GameObject cameraMenu;
    public GameObject coinCanvas;

	// Use this for initialization
	void Start () {
        memoria = GameObject.Find("Memoria");
	}
	
	// Update is called once per frame
	void Update () {

        if (cameraMenu.GetComponent<cameraMenu>().punt > 0)
        {
            totalcoinsT.enabled = true;
            coinCanvas.SetActive(true);
        }
        else
        {
            totalcoinsT.enabled = false;
            coinCanvas.SetActive(false);
        }
            totalcoinsT.text = memoria.GetComponent<memoria>().totalcoins.ToString();
	}
}