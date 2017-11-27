using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class canvasPlay : MonoBehaviour {

    private GameObject player;
    public Text coinsPlayT;
    public Text chunksPlayT;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
        coinsPlayT.text = player.GetComponent<playerCoin>().coins.ToString();
        chunksPlayT.text = player.GetComponent<PlayerMove>().chunkRecord.ToString();

    }
}
