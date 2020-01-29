using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anuncio : MonoBehaviour {

    float timer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.GetComponent<UnityEngine.UI.Text>().text != "") {
            timer += Time.deltaTime;
            if (timer > 5)
                this.GetComponent<UnityEngine.UI.Text>().text = "";
        }
	}
}
