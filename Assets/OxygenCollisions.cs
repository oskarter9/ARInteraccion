using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenCollisions : MonoBehaviour {

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Hydrogen1")
        {
            Debug.Log("Hydrogen1 touching");
            gameObject.GetComponentInParent<H2OController>().touchingHyd1 = true;
        }

        if (c.gameObject.tag == "Hydrogen2")
        {
            Debug.Log("Hydrogen2 touching");
            gameObject.GetComponentInParent<H2OController>().touchingHyd2 = true;
        }
    }
}
