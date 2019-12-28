using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

    bool activo = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ambiente")
            activo = false;
        if (col.gameObject.tag == "Enemigo" && this.gameObject.GetComponent<Rigidbody>().velocity.magnitude>8 && activo)
        {
            Debug.Log("Enemigo tocado "+ this.gameObject.GetComponent<Rigidbody>().velocity.magnitude);
            col.gameObject.GetComponent<PatrullaZombie>().enabled = false;
            col.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        }
    }
}
