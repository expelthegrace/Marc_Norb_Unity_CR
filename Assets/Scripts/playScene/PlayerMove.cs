using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private GameObject memoria;
    public AudioSource saltA;
    public AudioSource atropA;
    public AudioSource woodA;
    public AudioSource splashA;
    public AudioSource acidA;
    //public GameObject splashP;

    public bool inlava;
    public float speed;
    public float offset = 0.1f;
    public Vector3 direccio;
    public float step;
    public float jumpDist; 
    public bool saltant;
    public bool landed;
    public bool intronc;
    public bool inroca;
    private GameObject checkFront;
    public GameObject cameraMain;

    private Transform tronc;
    public float troncOffset;

    public bool wall;
    public bool mort;
    public bool mortCanvas;
    public bool ofegat;

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

    private bool comprimirLow;
    private bool comprimirHi;
    private float scaleIni;
    private float scaleFinal;
    private float g;
    private float fallV;

  
    // Use this for initialization
    void Start() {
        inlava = false;
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
        comprimirLow = false;
        comprimirHi = false;
        scaleIni = transform.localScale.y;
        scaleFinal = scaleIni - 0.15f;
        ofegat = false;
        fallV = 0f;
        mortCanvas = mort;
        g = 0.5f;
        inroca = false;
        dist = 10f;
    }

    IEnumerator reset()
    {
        if (!god)
        {
            mort = true;


            memoria.GetComponent<memoria>().totalcoins += GetComponent<playerCoin>().coins;
            if (memoria.GetComponent<memoria>().pantalla == 1) memoria.GetComponent<memoria>().best1 = Mathf.Max(memoria.GetComponent<memoria>().best1, chunkRecord);
            else if (memoria.GetComponent<memoria>().pantalla == 2) memoria.GetComponent<memoria>().best2 = Mathf.Max(memoria.GetComponent<memoria>().best2, chunkRecord);
            else if (memoria.GetComponent<memoria>().pantalla == 3) memoria.GetComponent<memoria>().best3 = Mathf.Max(memoria.GetComponent<memoria>().best3, chunkRecord);


            yield return new WaitForSeconds(0.5f);
            mortCanvas = true;
            memoria.GetComponent<memoria>().guardar(); // es guarda sol cada cop que acabes una partida
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
                saltA.Play();
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
                saltA.Play();

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
                dstPosition = new Vector3(dstX, transform.position.y + direccio.y * step, transform.position.z + direccio.z * step);
                tStep = 0;
                yPos = transform.position.y;
                saltant = true;
                enMoviment = true;
                saltA.Play();


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
                saltA.Play();

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
            comprimirLow = true;
        }
        if (intronc && !saltant)
        {
            transform.position = transform.position + new Vector3(tronc.position.x - transform.position.x + troncOffset, 0, 0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ofegat || inlava)
        {
            transform.position += new Vector3(0, -fallV, 0);
            if (memoria.GetComponent<memoria>().pantalla != 3 && !inlava) fallV += g; 
            else fallV = 0.1f; // en lava o acid
        }

        if (!mort && !ofegat)
        {
            if (Input.GetKeyDown(KeyCode.G)) god = !god;  // per ferse inmortal
                                                          // comprimir el player al caure
            float scaleF = 0.08f;
            if (comprimirLow)
            {
                
                transform.localScale += new Vector3(0, -scaleF, 0);           
                if (transform.localScale.y <= scaleFinal)
                {
                    transform.localScale = new Vector3(transform.localScale.x, scaleFinal, transform.localScale.z);
                    comprimirHi = true;
                    comprimirLow = false;
                }
            }
           else if (comprimirHi)
            {
                
                transform.localScale += new Vector3(0, scaleF, 0);             
                if (transform.localScale.y >= scaleIni)
                {
                    transform.localScale = new Vector3(transform.localScale.x, scaleIni, transform.localScale.z);
                    comprimirHi = false;
                }
            }
            
            chunkRecord = Mathf.Max((int)transform.position.z / (int)step, chunkRecord);

            // orientar el player i comprovar obstacles
            orientar();
            // moure/saltar player step by step
            if (enMoviment || intronc) moure();
            if (inroca && !saltant)
            {
                Physics.Raycast(transform.position + new Vector3(0, 5, 0), -Vector3.up, out hit, dist);
                if (hit.collider.gameObject.tag == "roca") transform.position = new Vector3(transform.position.x, hit.collider.bounds.max.y, transform.position.z);
                else if (hit.collider.gameObject.tag == "lava")
                {
                    inlava = true;
                    acidA.Play();
                    StartCoroutine(reset());
                }

            }
            // raig que detecta el terra al aterrar d'un salt i ubica en Y el player
      
           
            if (landed && Physics.Raycast(transform.position + new Vector3(0, 5, 0), -Vector3.up, out hit, dist))
            {
                if (hit.collider.gameObject.tag == "Terra")
                {
                    intronc = false;
                    saltant = false;
                    landed = false;
                    inroca = false;

                    transform.position = new Vector3(transform.position.x, hit.collider.bounds.max.y, transform.position.z);
                }
                else if (hit.collider.gameObject.tag == "tronc")
                {
                    saltant = false;
                    inroca = false;
                    landed = false;

                    transform.position = new Vector3(transform.position.x, hit.collider.bounds.max.y, transform.position.z);
                    intronc = true;
                    tronc = hit.collider.transform;
                    troncOffset = transform.position.x - tronc.position.x;
                   
                   
                }
                else if (hit.collider.gameObject.tag == "water")
                {
                    ofegat = true;
                    splashA.Play();
                    //splashP.GetComponent<ParticleSystem>().Play();
                    StartCoroutine(reset());
                }
                
                else if (hit.collider.gameObject.tag == "roca")
                {
                    intronc = false;
                    saltant = false;
                    landed = false;
                    inroca = true;
                    intronc = false;

                }
                else if (hit.collider.gameObject.tag == "lava")
                {
                    inlava = true;
                    acidA.Play();
                    StartCoroutine(reset());
                }
            }

            if (transform.position.z < cameraMain.GetComponent<cameraMove>().limitZ - 24) StartCoroutine(reset());
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (!mort)
        {
            if (collision.transform.tag == "cotxe")
            {
                atropA.Play();
                StartCoroutine(reset());
                transform.localScale += new Vector3(0, -1.2f, 0);
            }
            else if (collision.transform.tag == "tren")
            {
                atropA.Play();
                StartCoroutine(reset());
                transform.localScale += new Vector3(0, -1.2f, 0);
            }

            else if (collision.transform.tag == "tronc")
            {
                woodA.Play();
            }

        }
    }
     void OnTriggerExit(Collider col)
    {
        //wall = false;
    }
}

/* el surt de colisio del ckeck no surt quan toca, surt abans
 *   */
