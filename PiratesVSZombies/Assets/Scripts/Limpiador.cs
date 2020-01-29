using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limpiador : MonoBehaviour {

    float timerLimpiado = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.tag=="Abatido")
        {
            timerLimpiado += Time.deltaTime;
            if (timerLimpiado > 5)
                Destroy(gameObject);
        }
    }
}
