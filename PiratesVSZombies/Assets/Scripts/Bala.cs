using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

    bool activo = true;
    public float timer = 0;
    // Use this for initialization
    public static int nZombies = 0;
    public int limite=2;
    GameObject tesoro;
    bool cofreSinColocar = true;
    public GameObject texto;
    bool anuncio = false;

	void Start () {
		texto= GameObject.Find("Anuncio");
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.tag == "Inactivo") {
            timer += Time.deltaTime;
            if (timer > 5f) {
                Destroy(this.gameObject);
            }
        }
	}

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Enemigo")
        {
            activo = false;
            this.gameObject.tag = "Inactivo";
        }
        if (col.gameObject.tag == "Enemigo" && this.gameObject.GetComponent<Rigidbody>().velocity.magnitude>8 && activo)
        {

            Debug.Log("Enemigo tocado "+ this.gameObject.GetComponent<Rigidbody>().velocity.magnitude);
            col.gameObject.GetComponent<PatrullaZombie>().enabled = false;
            col.gameObject.GetComponent<Animator>().enabled = false;
            //col.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            //col.gameObject.GetComponent<BoxCollider>().enabled = false;
            col.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            activo = false;
            this.gameObject.tag = "Inactivo";
            nZombies++;
            Debug.Log("Zombies abatidos: " + nZombies);
            col.gameObject.tag = "Abatido";
            Manager.score += 100;

            if (nZombies >= limite && cofreSinColocar)
            {
                
                tesoro = GameObject.Find("Tesoro");
                GameObject.Find("Spawns").GetComponent<Spawner>().enabled=true;
                tesoro.GetComponent<Cofre>().colocarCofre();
                Debug.Log("Ha funcionado");
                cofreSinColocar = false;
                if (!anuncio)
                {
                    texto.GetComponent<UnityEngine.UI.Text>().text = "El Cofre acaba de salir";
                    anuncio = true;
                }
            }

        }
    }
}
