using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour {

    public GameObject bala;
    public Transform origen;
    public float fuerzaCanon = 30000;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            GameObject proyectil = Instantiate(bala);
            proyectil.transform.position = origen.position;
            Rigidbody rb = proyectil.GetComponent<Rigidbody>();
            //rb.velocity=Camera.main.transform.forward * 30;
            rb.AddForce(Camera.main.transform.forward * fuerzaCanon);
        }
	}
}
