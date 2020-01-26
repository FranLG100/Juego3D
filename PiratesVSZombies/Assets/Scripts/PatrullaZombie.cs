using UnityEngine;
using System.Collections;

public class PatrullaZombie : MonoBehaviour
{

    [SerializeField]
    Transform[] ruta;
    int puntoDeRuta;
    UnityEngine.AI.NavMeshAgent agent;
    public GameObject player;
    public bool perseguir;
    public GameObject ojos;
    public float timer=0;
    public bool preparandoFinal = false;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.autoBraking = false;
        SiguientePunto();
    }

    void SiguientePunto()
    {
        if (ruta.Length == 0)
        {
            return;
        }
        agent.destination = ruta[puntoDeRuta].position;
        puntoDeRuta = (puntoDeRuta + 1) % ruta.Length;
    }

    void perseguirJugador() {

        agent.destination = player.transform.position;

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Proyectil") { 
            perseguir = true;
            Debug.Log("Enemigo avistado");
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Proyectil") {
        
            ojos.SetActive(false);
        }
        if (col.gameObject.tag == "Player" && ojos.active) {
            col.gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            col.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            col.gameObject.GetComponentInChildren<Canon>().enabled = false;
            preparandoFinal = true;
            Debug.Log("MUERTO");
        }
    }

    void Update()
    {
        if (preparandoFinal)
        {
            timer += Time.deltaTime;
            if (timer > 6)
            {
                Application.LoadLevel("MenuPrincipal");
            }
        }
        if (perseguir)
            perseguirJugador();
        else
        {
            if (agent.remainingDistance < 0.5f)
            {
                SiguientePunto();
            }
        }
    }
}
