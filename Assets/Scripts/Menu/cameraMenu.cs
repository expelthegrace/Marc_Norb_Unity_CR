using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class cameraMenu : MonoBehaviour {

    private GameObject memoria;
    public GameObject playButton;
    public GameObject avatarButton;

    public GameObject backButton;

    public GameObject map1Button;

    public GameObject lock2B;
    public GameObject lock3B;

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

    private bool lock2;
    private bool lock3;

	// Use this for initialization
	void Start () {
        transform.position = point1.transform.position;
        punt = 0;
        smooth = 0.08f;
        maxSpeed = 10f;
        inmove = false;
        actualTime = 0f;
        lastTime = 0f;
        memoria = GameObject.Find("Memoria");

    }
	
	// Update is called once per frame
	void Update () {
        lock2 = !memoria.GetComponent<memoria>().avatar2;
        lock3 = !memoria.GetComponent<memoria>().avatar3;


        if (punt == 0) // menu
        {
            playButton.SetActive(true);
            avatarButton.SetActive(true);        
            map1Button.SetActive(false);
            backButton.SetActive(false);
            lock2B.SetActive(false);
            lock3B.SetActive(false);
        }
        else if (punt == 1) // avatar selection
        {
            playButton.SetActive(true);
            avatarButton.SetActive(false);
            map1Button.SetActive(false);
            backButton.SetActive(true);
            if (lock2) lock2B.SetActive(true);
            if (lock3) lock3B.SetActive(true);


        }
        else if (punt == 2) // map selection
        {
            playButton.SetActive(false);
            avatarButton.SetActive(true);
            map1Button.SetActive(true);
            backButton.SetActive(true);
            lock2B.SetActive(false);
            lock3B.SetActive(false);


        }
        /*
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

        }*/

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
