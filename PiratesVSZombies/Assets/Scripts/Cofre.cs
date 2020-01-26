using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour {

    public Transform[] posiciones;
    int aleatorio;
    

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void colocarCofre() {
        aleatorio = Random.Range(0, posiciones.Length);
        gameObject.transform.position = posiciones[aleatorio].position;
    }
}
