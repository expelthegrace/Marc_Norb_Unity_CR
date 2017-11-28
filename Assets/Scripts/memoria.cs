using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memoria : MonoBehaviour {

    private static memoria instanceRef;
    public int totalcoins;
    public int playerSelect;
    public bool avatar2;
    public bool avatar3;

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
        totalcoins = 100;
        avatar2 = false;
        avatar3 = false;            // borrar
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
