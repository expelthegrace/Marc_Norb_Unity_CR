using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public GameObject respawn;

    public float speed;
    public float offset = 0.1f;
    public Vector3 direccio;
    public float step;
    public float jumpDist; // ?
    private float maxJump; // ?
    public float fallingSpeed;
    public bool saltant;
    public bool landed;
    private bool intronc;
    private GameObject checkFront;

    private Transform tronc;
    public float troncOffset;


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

    public float dstX;
    public int chunkAct;
    // Use this for initialization
    void Start() {
        speed = 13;
        enMoviment = false;
        direccio = frontDir;
        step = 12;
        jumpDist = 3;
        maxJump = transform.position.y + jumpDist;
        saltant = false;
        landed = true;
        intronc = false;
        checkFront = GameObject.Find("checkFront");
    }

    void reset()
    {
        intronc = false;
        enMoviment = false;
        saltant = false;
        landed = true;
        transform.rotation = Quaternion.LookRotation(frontDir);
        direccio = frontDir;
        transform.position = respawn.transform.position;
    }
    void orientar()
    {
        Debug.DrawRay(transform.position + new Vector3(0, 3, 0), Vector3.forward * (step + step / 3), Color.green);
        // orientar i setejar moviment del player
        if (Input.GetKey(KeyCode.UpArrow) && !enMoviment)
        {   // si no hi ha una paret

            if (!Physics.Raycast(transform.position + new Vector3(0, 3, 0), Vector3.forward, out hit, step + step / 3) || hit.collider.gameObject.tag != "wall" && !checkFront.GetComponent<checkFront>().wall)
            {
                if (direccio != frontDir)
                {
                    transform.rotation = Quaternion.LookRotation(frontDir);
                    direccio = frontDir;
                }
                srcPosition = transform.position;
                dstX = ((int)(transform.position.x + direccio.x * step) / (int)step) * step;
                //transform.position.x + direccio.x * step
                dstPosition = new Vector3(dstX, transform.position.y + direccio.y * step, transform.position.z + direccio.z * step);
                tStep = 0;
                yPos = transform.position.y;
                saltant = true;
                enMoviment = true;
            }
            else
            {
                Debug.Log("Colisio frontal");
                transform.rotation = Quaternion.LookRotation(frontDir);
                direccio = frontDir;
            }
        }

        else if (Input.GetKey(KeyCode.RightArrow) && !enMoviment)
        {
            if (!Physics.Raycast(transform.position + new Vector3 (0,3,0), Vector3.right, out hit, step + step / 3) || hit.collider.gameObject.tag != "wall")
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
            else
            {
                Debug.Log("Colisio dreta");
                transform.rotation = Quaternion.LookRotation(rightDir);
                direccio = rightDir;
            }
        }

        else if (Input.GetKey(KeyCode.DownArrow) && !enMoviment)
        {
            if (!Physics.Raycast(transform.position + new Vector3(0, 3, 0), -Vector3.forward, out hit, step + step / 3) || hit.collider.gameObject.tag != "wall")
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
            else
            {
                Debug.Log("Colisio trasera");
                transform.rotation = Quaternion.LookRotation(downDir);
                direccio = downDir;
            }

        }

        else if (Input.GetKey(KeyCode.LeftArrow) && !enMoviment)
        {
            if (!Physics.Raycast(transform.position + new Vector3(0, 3, 0), Vector3.left, out hit, step + step / 3) || hit.collider.gameObject.tag != "wall")
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
            else
            {
                Debug.Log("Colisio trasera");
                transform.rotation = Quaternion.LookRotation(leftDir);
                direccio = leftDir;
            }

        }
    }

    void moure()
    {
        if (saltant) yPos = Mathf.Sin(tStep * Mathf.PI) * jumpDist;

        transform.position = Vector3.Lerp(srcPosition, dstPosition, tStep) + new Vector3(0, yPos, 0);
        tStep += Time.deltaTime * 6f; // dura 1/6 segons

        if (transform.position.z == dstPosition.z && transform.position.x == dstPosition.x)
        {
            enMoviment = false;
            landed = true;
        }
        if (intronc && !saltant)
        {

            transform.position = transform.position + new Vector3(tronc.position.x - transform.position.x + troncOffset, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        chunkAct = (int)transform.position.x / (int)step;
       
        // orientar el player i comprovar obstacles
        orientar();
        // moure/saltar player step by step
        if (enMoviment || intronc) moure();
        
        // raig que detecta el terra al aterrar d'un salt i ubica en Y el player
        dist = 10f;
        //Debug.DrawRay(transform.position + new Vector3(0, 10, 0), -Vector3.up, Color.green,dist);
        if (Physics.Raycast(transform.position+ new Vector3 (0,5,0), -Vector3.up, out hit, dist) && landed)
        {
            if (hit.collider.gameObject.tag == "Terra")
            {
                intronc = false;
                saltant = false;
                landed = false;
                transform.position = new Vector3(transform.position.x, hit.collider.bounds.max.y, transform.position.z);
            }
            else if (hit.collider.gameObject.tag == "tronc")
            {
                saltant = false;
                landed = false;
                transform.position = new Vector3(transform.position.x, hit.collider.bounds.max.y, transform.position.z);
                intronc = true;
                tronc = hit.collider.transform;
                troncOffset = transform.position.x - tronc.position.x;
                //Debug.Log("tronc");
            }
            else if (hit.collider.gameObject.tag == "mortal") reset();
        }

    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("colisio");
        if (collision.transform.tag == "mortal") reset();
        
    }
}

/* el surt de colisio del ckeck no surt quan toca, surt abans
 *   */
