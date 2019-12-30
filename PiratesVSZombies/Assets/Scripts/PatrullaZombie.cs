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
        if (col.gameObject.tag == "Player") {
            col.gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            col.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    void Update()
    {
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
