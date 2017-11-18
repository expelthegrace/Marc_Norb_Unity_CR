using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed;
    public float offset = 0.1f;
    public Vector3 direccio;
    public float step;

    private Vector3 frontDir = new Vector3(0, 0, 1);
    private Vector3 leftDir  = new Vector3(-1, 0, 0);
    private Vector3 rightDir = new Vector3(1, 0, 0);
    private Vector3 downDir  = new Vector3(0, 0, -1);


    public float tStep;
    public Vector3 srcPosition;
    public Vector3 dstPosition;

    private float dist = 1f;
    private RaycastHit hit;

    private bool enMoviment;
    // Use this for initialization
    void Start() {
        speed = 13;
        enMoviment = false;
        direccio = frontDir;
        step = 12;
    }

    // Update is called once per frame
    void Update()
    {

        // orientar i setejar moviment del player
        if (Input.GetKey(KeyCode.UpArrow) && !enMoviment)
        {
            if (direccio != frontDir)
            {
                transform.rotation = Quaternion.LookRotation(frontDir);
                direccio = frontDir;
            }
            srcPosition = transform.position;
            dstPosition = transform.position + direccio * step;
            tStep = 0;
            enMoviment = true;
        }

        if (Input.GetKey(KeyCode.RightArrow) && !enMoviment)
        {
            if (direccio != rightDir)
            {
                transform.rotation = Quaternion.LookRotation(rightDir);
                direccio = rightDir;
            }
            srcPosition = transform.position;
            dstPosition = transform.position + direccio * step;
            tStep = 0;
            enMoviment = true;
        }

        if (Input.GetKey(KeyCode.DownArrow) && !enMoviment)
        {
            if (direccio != downDir)
            {
                transform.rotation = Quaternion.LookRotation(downDir);
                direccio = downDir;
            }
            srcPosition = transform.position;
            dstPosition = transform.position + direccio * step;
            tStep = 0;
            enMoviment = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && !enMoviment)
        {
            if (direccio != leftDir)
            {
                transform.rotation = Quaternion.LookRotation(leftDir);
                direccio = leftDir;
            }
            srcPosition = transform.position;
            dstPosition = transform.position + direccio * step;
            tStep = 0;
            enMoviment = true;
        }

        // moure player step by step
        if (enMoviment)
        {
            transform.position = Vector3.Lerp(srcPosition, dstPosition, tStep);
            tStep += Time.deltaTime* 6;
            if (transform.position == dstPosition) enMoviment = false;
        }

        // ray de colisio amb el terra
        dist = 10;
        Debug.DrawRay(transform.position, -Vector3.up * dist, Color.green);
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, dist))
        {
            if (hit.collider.gameObject.tag == "Terra") Debug.Log("Colisio amb terra");
        }



    }
        
}
