using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bestSurface : MonoBehaviour {
    private RaycastHit hit;
    public GameObject bloc;
    public float dreta;
    public float esquerra;
    public float espai;
    // Use this for initialization
    void Start()
    {
        espai = 8;
        if (Physics.Raycast(transform.position + new Vector3(0, 0, 0), -Vector3.up, out hit, 30))
        {
            if (hit.collider.gameObject.tag == "Terra" || hit.collider.gameObject.tag == "mortal")
            {

                transform.position = new Vector3(transform.position.x, hit.collider.bounds.max.y + 1, transform.position.z-4);
            }
            else if (hit.collider.gameObject.tag == "wall")
            {

                transform.position = new Vector3(transform.position.x, hit.collider.bounds.min.y + GetComponent<Collider>().bounds.size.y + 1, transform.position.z - 4);
            }
        }
        dreta = GetComponent<Collider>().bounds.max.x + espai;
        for (int i = 0; i < 30; ++i)
        {
            Instantiate(bloc, new Vector3(dreta + i * espai, transform.position.y + 0.3f, transform.position.z+4), bloc.transform.rotation, transform);
        }
        esquerra = GetComponent<Collider>().bounds.min.x - espai;
        for (int i = 0; i < 30; ++i)
        {
            Instantiate(bloc, new Vector3(esquerra - i * espai, transform.position.y + 0.3f, transform.position.z + 4), bloc.transform.rotation, transform);
        }
    }

}
