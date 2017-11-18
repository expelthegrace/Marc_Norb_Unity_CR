using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed;
    public float offset = 0.1f;
    public Vector3 direccio;
    public float step;
    public float jumpDist; // ?
    private float maxJump; // ?
    public float fallingSpeed;
    public bool saltant;
    public bool landed;


    private Vector3 frontDir = new Vector3(0, 0, 1);
    private Vector3 leftDir  = new Vector3(-1, 0, 0);
    private Vector3 rightDir = new Vector3(1, 0, 0);
    private Vector3 downDir  = new Vector3(0, 0, -1);


    public float tStep;
    public Vector3 srcPosition;
    public Vector3 dstPosition;
    private float yPos;

    private float dist = 1f;
    private RaycastHit hit;

    private bool enMoviment;
    // Use this for initialization
    void Start() {
        speed = 13;
        enMoviment = false;
        direccio = frontDir;
        step = 12;
        jumpDist = 4;
        maxJump = transform.position.y + jumpDist;
        saltant = false;
        landed = true;
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
            yPos = transform.position.y;
            saltant = true;
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
            yPos = transform.position.y;
            saltant = true;
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
            yPos = transform.position.y;
            saltant = true;
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
            yPos = transform.position.y;
            saltant = true;
            enMoviment = true;
        }

        // moure/saltar player step by step
        if (enMoviment) 
        {
            //yPos = srcPosition.y + Mathf.Lerp(srcPosition.y, maxJump, tStep);
           if (saltant) yPos = Mathf.Sin(tStep * Mathf.PI) * jumpDist;

            transform.position = Vector3.Lerp(srcPosition, dstPosition, tStep) + new Vector3 (0,yPos,0);
            tStep += Time.deltaTime* 4f; // dura 1/6 segons

            if (transform.position.z == dstPosition.z && transform.position.x == dstPosition.x)
            {
                enMoviment = false;
                landed = true;
            }
        }

        // raig que detecta el terra al aterrar d'un salt i ubica en Y el player
        dist = 10f;
        //Debug.DrawRay(transform.position + new Vector3(0, 10, 0), -Vector3.up, Color.green,dist);
        if (Physics.Raycast(transform.position+ new Vector3 (0,5,0), -Vector3.up, out hit, dist) && landed)
        {
            if (hit.collider.gameObject.tag == "Terra")
            {
                saltant = false;
                landed = false;
                Debug.Log(hit.collider.bounds.max.y);
                transform.position = new Vector3(transform.position.x, hit.collider.bounds.max.y, transform.position.z);

            }
        }




    }
        
}
