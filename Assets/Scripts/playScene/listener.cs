﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class listener : MonoBehaviour {
    public GameObject player;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position;
	}
}
