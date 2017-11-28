using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatPont : MonoBehaviour
{

    public bool simulate;
    private float Yini;
    public float deep;
    private float timeActual;
    private float Ysrc;
    private float Ydst;
    private float tStep;
    private int fase;

    // Use this for initialization
    void Start()
    {
        simulate = false;
        Yini = transform.position.y;
        deep = 0.5f;
        timeActual = 0;
        fase = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (simulate && fase == 0)
        {
            transform.position = Vector3.Lerp(new Vector3(transform.position.x, Ysrc, transform.position.z), new Vector3(transform.position.x, Ydst, transform.position.z), tStep);
            tStep += Time.deltaTime * 6f; // dura 1/6 segons
            if (transform.position.y == Ydst)
            {
                Ysrc = transform.position.y;
                Ydst = Yini;
                fase = 1;
                tStep = 0f;
            }
        }

        else if (fase == 1 && simulate)
        {
            transform.position = Vector3.Lerp(new Vector3(transform.position.x, Ysrc, transform.position.z), new Vector3(transform.position.x, Ydst, transform.position.z), tStep);
            tStep += Time.deltaTime * 6f; // dura 1/6 segons
            if (transform.position.y == Ydst) simulate = false;
        }

        timeActual += Time.deltaTime;

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player" && !simulate)
        {
            Debug.Log("tronc player");
            simulate = true;
            tStep = 0f;
            Ysrc = Yini;
            Ydst = transform.position.y - deep;
            fase = 0;
        }
    }

}
