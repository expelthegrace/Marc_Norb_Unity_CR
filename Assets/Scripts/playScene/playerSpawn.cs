using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpawn : MonoBehaviour {

    public GameObject model1;
    public GameObject model2;
    public GameObject model3;

    private memoria mem;

	// Use this for initialization
	void Start () {
        mem = GameObject.Find("Memoria").GetComponent<memoria>();
        switch (mem.playerSelect) // 1 2 i 3
        {
            case 1:
                Instantiate(model1, new Vector3(0, 0, 0), model1.transform.rotation, transform);
                break;
            case 2:
                Instantiate(model2, new Vector3(0, 0, 0), model2.transform.rotation, transform);
                break;
            case 3:
                Instantiate(model3, new Vector3(0, 0, 0), model3.transform.rotation, transform);
                break;
            default:
                Debug.Log("player no selected");
                break;
        }
        Debug.Log("player selected:" + mem.playerSelect.ToString());
	}
	
	// Update is called once per frame

}
