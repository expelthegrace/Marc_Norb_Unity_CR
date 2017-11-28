using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memoria : MonoBehaviour {

    private static memoria instanceRef;
    public int totalcoins;
    public int playerSelect;

    void Awake()
    {
        if (instanceRef == null)
        {
            instanceRef = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        totalcoins = 0;
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
