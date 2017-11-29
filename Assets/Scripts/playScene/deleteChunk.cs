using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteChunk : MonoBehaviour {

    private GameObject cameraMain;
    private memoria memoria;

    void Awake()
    {
        cameraMain = GameObject.Find("Main Camera");
        Debug.Log(cameraMain);
    }

	// Use this for initialization
	void Start () {

        memoria = GameObject.Find("Memoria").GetComponent<memoria>();
	}
	
	// Update is called once per frame
	void Update () {
        if (memoria.pantalla != 0 && cameraMain.transform.position.z - 12*2 > transform.position.z)
        {
            Debug.Log("elim");
            Destroy(gameObject);
        }
    }
}
