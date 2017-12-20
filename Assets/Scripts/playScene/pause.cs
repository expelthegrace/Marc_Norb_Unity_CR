using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour {
    public GameObject player;
    public GameObject canvasPlay;
    private Vector3 offset;

    public AudioSource click;
    public AudioSource dashA;

    private bool activarPause;
    private bool paused;

    private float actualTime;
    private float lastTime;
    private Vector3 vel;

    public float smooth;
    // Use this for initialization
    void Start () {
        offset = canvasPlay.transform.position - transform.position;
        actualTime = 0f;
        lastTime = 0f;
        smooth = 0.1f;
        paused = false;
        activarPause = false;
    }

    IEnumerator pausarGO()
    {
        yield return new WaitForSeconds(0.4f);
        Time.timeScale = 0f;
        paused = true;
        activarPause = false;
    }

    public void despausar()
    {
        dashSound();
        Time.timeScale = 1f;
        paused = false;
        activarPause = false;
        Debug.Log("despausar");
    }

    public void pausar()
    {
        dashSound();
        activarPause = true;
        StartCoroutine(pausarGO());
        Debug.Log("pausar");
    }

    void OnGUI()
    {

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && !activarPause && !paused && !player.GetComponent<PlayerMove>().mort && !player.GetComponent<PlayerMove>().saltant)
        {
            pausar();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused)
        {           
            despausar();

        }

        if (activarPause || paused)
        {
            transform.position = Vector3.SmoothDamp(transform.position, canvasPlay.transform.position, ref vel, smooth);
        }
        else transform.position = Vector3.SmoothDamp(transform.position, canvasPlay.transform.position - offset, ref vel, smooth);

      
        actualTime += Time.deltaTime;
	}

    public void clickSound()
    {
        click.Play();
    }
    public void dashSound()
    {
        dashA.Play();
    }
}
