using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class cameraMenu : MonoBehaviour {

    private memoria memoria;
    public GameObject playButton;
    public GameObject avatarButton;
    public GameObject dashA;
    public GameObject cachingA;
    public GameObject selectA;
    public GameObject nopeA;

    public GameObject backButton;

    public GameObject map1Button;

    public GameObject lock2B;
    public GameObject lock3B;

    public GameObject select1B;
    public GameObject select1T;
    public GameObject select2B;
    public GameObject select2T;
    public GameObject select3B;
    public GameObject select3T;

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

    public bool avatar2;
    public bool avatar3;

    private int totalcoins;

    // Use this for initialization
    void Start () {
        transform.position = point1.transform.position;
        punt = 0;
        smooth = 0.08f;
        maxSpeed = 10f;
        inmove = false;
        actualTime = 0f;
        lastTime = 0f;
        memoria = GameObject.Find("Memoria").GetComponent<memoria>();
        memoria.pantalla = 0;
    }
	
	// Update is called once per frame
	void Update () {
        avatar2 = memoria.avatar2;
        avatar3 = memoria.avatar3;
       

        totalcoins = memoria.totalcoins;
        if (punt == 0) // menu
        {
            playButton.SetActive(true);
            avatarButton.SetActive(true);        
            map1Button.SetActive(false);
            backButton.SetActive(false);
            lock2B.SetActive(false);
            lock3B.SetActive(false);

            select1B.SetActive(false);
            select1T.SetActive(false);
            select2B.SetActive(false);
            select2T.SetActive(false);
            select3B.SetActive(false);
            select3T.SetActive(false);

        }
        else if (punt == 1) // avatar selection
        {
            playButton.SetActive(true);
            avatarButton.SetActive(false);
            map1Button.SetActive(false);
            backButton.SetActive(true);
            lock2B.SetActive(!avatar2);
            lock3B.SetActive(!avatar3);

            select1B.SetActive(true);
            select1T.SetActive(memoria.playerSelect == 1);
            select2B.SetActive(true);
            select2T.SetActive(memoria.playerSelect == 2);
            select3B.SetActive(true);
            select3T.SetActive(memoria.playerSelect == 3);


        }
        else if (punt == 2) // map selection
        {
            playButton.SetActive(false);
            avatarButton.SetActive(true);
            map1Button.SetActive(true);
            backButton.SetActive(true);
            lock2B.SetActive(false);
            lock3B.SetActive(false);

            select1B.SetActive(false);
            select1T.SetActive(false);
            select2B.SetActive(false);
            select2T.SetActive(false);
            select3B.SetActive(false);
            select3T.SetActive(false);


        }

        //moure camera
        if (inmove)
        {
            Vector3 v = new Vector3();
            transform.position = Vector3.SmoothDamp(transform.position,dest , ref v, smooth);
          if (actualTime - lastTime > 1.5f) inmove = false;
        }

        
        actualTime += Time.deltaTime;
	}

    public void clickPlay()
    {
        dashA.GetComponent<AudioSource>().Play();
        punt = 2;
        inmove = true;
        dest = point3.transform.position;
        lastTime = actualTime;
    }
    public void clickAvatar()
    {
        dashA.GetComponent<AudioSource>().Play();
        punt = 1;
        inmove = true;
        dest = point2.transform.position;
        lastTime = actualTime;
    }
    public void clickBack()
    {
        dashA.GetComponent<AudioSource>().Play();
        punt = 0;
        inmove = true;
        dest = point1.transform.position;
        lastTime = actualTime;
    }
    public void loadLevel(int i)
    {
        if (i == 1)
        {
            memoria.pantalla = 1;
            SceneManager.LoadScene("scena1");
        }
    }

    public void unlock(int p)
    {
        if (p == 2)
        { // desbloquejar 2n avatar
            if (totalcoins >= 50)
            {
                cachingA.GetComponent<AudioSource>().Play();
                memoria.totalcoins -= 50;
                memoria.avatar2 = true;
            }
            else
            {
                nopeA.GetComponent<AudioSource>().Play();
            }
        }

        else if (p == 3)
        { // desbloquejar 2n avatar
            if (totalcoins >= 1000)
            {
                cachingA.GetComponent<AudioSource>().Play();
                memoria.totalcoins -= 1000;
                memoria.avatar3 = true;

            }
            else
            {
                nopeA.GetComponent<AudioSource>().Play();

            }
        }
    }

    public void selectAvatar(int a)
    {
        
        if (a == 1)
        {
            selectA.GetComponent<AudioSource>().Play();
            memoria.playerSelect = 1;
        }
        else if (a == 2 && avatar2)
        {
            selectA.GetComponent<AudioSource>().Play();
            memoria.playerSelect = 2;
        }
        else if (a == 3 && avatar3)
        {
            selectA.GetComponent<AudioSource>().Play();
            memoria.playerSelect = 3;
        }
    }
}
