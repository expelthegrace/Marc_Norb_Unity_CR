using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private GameObject memoria;
    public GameObject respawn;

    public float speed;
    public float offset = 0.1f;
    public Vector3 direccio;
    public float step;
    public float jumpDist; 
    public bool saltant;
    public bool landed;
    private bool intronc;
    private GameObject checkFront;
    public GameObject cameraMain;

    private Transform tronc;
    public float troncOffset;

    public bool wall;
    public bool mort;

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

    public bool enMoviment;
    public bool god;

    public float dstX;
    public int chunkRecord;
    // Use this for initialization
    void Start() {
        speed = 13; // 13
        enMoviment = false;
        direccio = frontDir;
        step = 12;
        jumpDist = 3;
        saltant = false;
        landed = true;
        intronc = false;
        mort = false;
        checkFront = GameObject.Find("checkFront");
        god = false;
        memoria = GameObject.Find("Memoria");
        memoria.GetComponent<memoria>().pantalla = 1;
    }

    void reset()
    {
        if (!god)
        { 
            intronc = false;
            enMoviment = false;
            saltant = false;
            landed = true;
            transform.rotation = Quaternion.LookRotation(frontDir);
            direccio = frontDir;
            transform.position = respawn.transform.position;
            mort = true;
            // ^^ eliminable si no godmode
            
            memoria.GetComponent<memoria>().totalcoins += GetComponent<playerCoin>().coins;
            GetComponent<playerCoin>().coins = 0;
            memoria.GetComponent<memoria>().best1 = Mathf.Max(memoria.GetComponent<memoria>().best1, chunkRecord);
            SceneManager.LoadScene("scena1");
            
            chunkRecord = 0;
        }
    }

    void orientar()
    {

        //Debug.DrawRay(transform.position + new Vector3(0, 3, 0), Vector3.forward * (step + step / 3), Color.green);
        // orientar i setejar moviment del player
        if (Input.GetKey(KeyCode.UpArrow) && !enMoviment)
        {   // si no hi ha una paret

            if ((!Physics.Raycast(transform.position + new Vector3(0, 3, 0), Vector3.forward, out hit, step + step / 3) ||hit.collider.gameObject.tag != "wall") && !wall)
            {
                if (direccio != frontDir)
                {
                    transform.rotation = Quaternion.LookRotation(frontDir);
                    direccio = frontDir;
                }
                int signe = 1;
                if (transform.position.x + direccio.x < 0) signe = -1;
                else signe = 1;

                srcPosition = transform.position;
                dstX = ((int)(transform.position.x + direccio.x * step + step / 2 * signe) / (int)step) * step;
                //transform.position.x + direccio.x * step
                dstPosition = new Vector3(dstX, transform.position.y + direccio.y * step, transform.position.z + direccio.z * step);
                tStep = 0;
                yPos = transform.position.y;
                saltant = true;
                enMoviment = true;
            }
            else
            {
                transform.rotation = Quaternion.LookRotation(frontDir);
                direccio = frontDir;
            }
        }

        else if (Input.GetKey(KeyCode.RightArrow) && !enMoviment)
        {
            if (!Physics.Raycast(transform.position + new Vector3(0, 3, 0), Vector3.right, out hit, step + step / 3) || hit.collider.gameObject.tag != "wall")
            {
                if (direccio != rightDir)
                {
                    transform.rotation = Quaternion.LookRotation(rightDir);
                    direccio = rightDir;
                }
                int signe = 1;
                if (transform.position.x + direccio.x < 0) signe = -1;
                else signe = 1;

                srcPosition = transform.position;
                dstX = ((int)(transform.position.x + direccio.x * step + step / 2 * signe) / (int)step) * step;
                //transform.position.x + direccio.x * step
                dstPosition = transform.position + direccio * step;
                tStep = 0;
                yPos = transform.position.y;
                saltant = true;
                enMoviment = true;
            }
            else
            {
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
                int signe = 1;
                if (transform.position.x + direccio.x < 0) signe = -1;
                else signe = 1;

                srcPosition = transform.position;
                dstX = ((int)(transform.position.x + direccio.x * step + step / 2 * signe) / (int)step) * step;
                dstPosition = transform.position + direccio * step;
                tStep = 0;
                yPos = transform.position.y;
                saltant = true;
                enMoviment = true;

            }
            else
            {
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
                int signe = 1;
                if (transform.position.x + direccio.x < 0) signe = -1;
                else signe = 1;

                srcPosition = transform.position;
                dstX = ((int)(transform.position.x + direccio.x * step + step / 2 * signe) / (int)step) * step;
                dstPosition = transform.position + direccio * step;
                tStep = 0;
                yPos = transform.position.y;
                saltant = true;
                enMoviment = true;
            }
            else
            {
                transform.rotation = Quaternion.LookRotation(leftDir);
                direccio = leftDir;
            }

        }
    }

    void moure()
    {
        if (saltant) yPos = Mathf.Sin(tStep * Mathf.PI) * jumpDist;

        transform.position = Vector3.Lerp(srcPosition, dstPosition, tStep) + new Vector3(0, yPos, 0);
        tStep += Time.deltaTime * 4.5f; // dura 1/6 segons

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
        if (Input.GetKeyDown(KeyCode.G)) god = !god;  // per ferse inmortal
        

        chunkRecord = Mathf.Max((int)transform.position.z / (int)step, chunkRecord);
       
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

        if (transform.position.z < cameraMain.GetComponent<cameraMove>().limitZ - 24) reset();

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "mortal") reset();

        /*if (collision.GetComponent<Collider>().tag == "wall")
        {
            wall = true;
        }*/

    }
    void OnTriggerExit(Collider col)
    {
        //wall = false;
    }
}

/* el surt de colisio del ckeck no surt quan toca, surt abans
 *   */
