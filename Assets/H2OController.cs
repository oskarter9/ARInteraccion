using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H2OController : MonoBehaviour
{

    public GameObject hydrogen1;
    public GameObject hydrogen2;
    public GameObject oxygen;

    public bool touchingHyd1;
    public bool touchingHyd2;

    public float maxDistance;

    private void Awake()
    {
        oxygen = this.transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        Debug.Log(hydrogen1.name);
        Debug.Log(hydrogen2.name);
        if (hydrogen1.GetComponent<MeshRenderer>().enabled && hydrogen2.GetComponent<MeshRenderer>().enabled && oxygen.GetComponent<MeshRenderer>().enabled){

            Vector3 h1Position = hydrogen1.transform.parent.position;
            Vector3 h2Position = hydrogen2.transform.parent.position;

            float distanceHyd1ToOxy = Vector3.Distance(h1Position, oxygen.transform.parent.position);
            float distanceHyd2ToOxy = Vector3.Distance(h2Position, oxygen.transform.parent.position);
            if (distanceHyd1ToOxy <= maxDistance && distanceHyd2ToOxy <= maxDistance)
            {
                Debug.Log("both close to the oxygen");
                Debug.Log("touchingHyd1 = " + touchingHyd1);
                Debug.Log("touchingHyd2 = " + touchingHyd2);
                if (!touchingHyd1){
                    hydrogen1.transform.Translate((hydrogen1.transform.parent.position - oxygen.transform.parent.position).normalized * 10f
                                              * Time.deltaTime);
                }

                if (!touchingHyd2){
                    hydrogen2.transform.Translate((hydrogen2.transform.parent.position - oxygen.transform.parent.position).normalized * 10f
                                              * Time.deltaTime);
                }


            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Hydrogen1")
        {
            touchingHyd1 = true;
        }

        if (other.gameObject.name == "Hydrogen2")
        {
            touchingHyd2 = true;
        }
    }

    /*
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Hydrogen2"){
            touchingHyd2 = true;
        }
        if (other.name == "Hydrogen1"){
            touchingHyd1 = false;
        }
    }
    */



}
