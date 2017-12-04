using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class canvasDead : MonoBehaviour {

    private GameObject player;
    public GameObject canvasPlay;
    private Vector3 offset;
    public bool playerMort;
    public bool activarDead;
    private float actualTime;
    private float lastTime;
    private Vector3 vel;
    private Vector3 dest;

    public Text coinsT;
    public Text metersT;

    public float smooth;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
        offset = canvasPlay.transform.position - transform.position;
        playerMort = false;
        actualTime = 0f;
        lastTime = 0f;
        activarDead = false;
        smooth = 0.8f;
	}
	
	// Update is called once per frame
	void Update () {
        playerMort = player.GetComponent<PlayerMove>().mortCanvas;

        if (!playerMort) transform.position = canvasPlay.transform.position - offset;
        else // si player mort
        {
            //dest = canvasPlay.transform.position;
            //canvasPlay.SetActive(false);
            activarDead = true;
            lastTime = actualTime;
        }
        if (activarDead)
        {
            metersT.text = "Your score: " + player.GetComponent<PlayerMove>().chunkRecord.ToString();
            coinsT.text = "Coins collected: " + player.GetComponent<playerCoin>().coins.ToString(); 
            transform.position = Vector3.SmoothDamp(transform.position, canvasPlay.transform.position, ref vel, smooth);
        }


        actualTime += Time.deltaTime;
	}

    public void click(int i)
    {
        // i == 0 reset
        if (i == 0)
        {
            //player music reset
            SceneManager.LoadScene("scena1");
        }
        // i == 1 menu
        else if (i == 1)
        {
            SceneManager.LoadScene("scenaMenu1");
        }
        
    }
}
