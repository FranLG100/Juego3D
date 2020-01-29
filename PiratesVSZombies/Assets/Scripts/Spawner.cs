using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Transform[] spawners;
    public float tiempoEspera;
    float timer;
    public GameObject enemigo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > tiempoEspera) {

            for (int i = 0; i < 4; i++)
            {
                int spawnerDesignado = Random.Range(0, spawners.Length);
                enemigo.GetComponent<UnityEngine.AI.NavMeshAgent>().Warp(new Vector3(spawners[spawnerDesignado].position.x, spawners[spawnerDesignado].position.y, spawners[spawnerDesignado].position.z));
                Instantiate(enemigo);
            }
           
            timer = 0;
        }
	}
}
