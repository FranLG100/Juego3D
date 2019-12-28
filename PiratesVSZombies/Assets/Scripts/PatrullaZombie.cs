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
