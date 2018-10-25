using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class H2OController : MonoBehaviour
{

    public GameObject hydrogen1;
    public GameObject hydrogen2;
    public GameObject oxygen;
    public Transform target1;
    public Transform target2;

    public bool touchingHyd1;
    public bool touchingHyd2;

    public float maxDistance;

    private bool updateMovement;

    private void Update()
    {
        if (!updateMovement){
            return;
        }
        if (hydrogen1.GetComponent<MeshRenderer>().enabled && hydrogen2.GetComponent<MeshRenderer>().enabled && oxygen.GetComponent<MeshRenderer>().enabled){

            Vector3 h1Position = hydrogen1.transform.parent.position; //posicion target hidrogeno1  
            Vector3 h2Position = hydrogen2.transform.parent.position; //posicion target hidrogeno2

            float distanceHyd1ToOxy = Vector3.Distance(h1Position, oxygen.transform.parent.position); //distancia target ox a hyd1
            float distanceHyd2ToOxy = Vector3.Distance(h2Position, oxygen.transform.parent.position); //distancia target ox a hyd2
            if (distanceHyd1ToOxy <= maxDistance && distanceHyd2ToOxy <= maxDistance)
            {
                Debug.Log("both close to the oxygen");
                Sequence s = DOTween.Sequence();
                s.AppendCallback(() =>
                {
                    hydrogen1.transform.DOMove(target1.position, 2f);
                    hydrogen2.transform.DOMove(target2.position, 2f);
                });
                s.OnComplete(() =>
                {
                    updateMovement = false;
                });
                
            }
        }

    }
}
