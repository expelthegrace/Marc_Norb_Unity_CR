using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Try : MonoBehaviour {
    public GameObject goAnim;
    public GameObject stopuF1;
    public GameObject stopuF2;
    public bool canGo;
    private float acum;

	// Use this for initialization
	void Start () {
        goAnim.SetActive(true);
        stopuF1.SetActive(false);
        stopuF2.SetActive(false);
        acum = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (canGo)
        {
            goAnim.SetActive(true);
            stopuF1.SetActive(false);
            stopuF2.SetActive(false);
        }
        else
        {
            if(acum < 0.75)
            {
                goAnim.SetActive(false);
                stopuF1.SetActive(true);
                stopuF2.SetActive(false);
            }
            else if(acum < 1.5)
            {
                goAnim.SetActive(false);
                stopuF1.SetActive(false);
                stopuF2.SetActive(true);
            }
            else
            {
                acum = 0;
            }
            acum += Time.deltaTime;
        }
    }
}
