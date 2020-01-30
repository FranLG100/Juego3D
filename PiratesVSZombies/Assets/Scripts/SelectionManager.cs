using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string etiquetaSeleccion = "Interactuable";
    [SerializeField] private Material seleccionado;
    public Material defaultMaterial;
    public Material newMaterial;
    private Transform _seleccion;
    public float timer = 0;
    public bool preparandoFinal = false;
    GameObject[] enemigos;

    private void Update()
    {

        if (preparandoFinal) {
            timer += Time.deltaTime;
            if (timer > 6)
            {
                Application.LoadLevel("MenuPrincipal");
            }
        }
        if (_seleccion != null)
        {
            var selectionRenderer = _seleccion.GetComponent<Renderer>();
            selectionRenderer.material.SetColor("_EmissionColor", Color.black);
            _seleccion = null;
            //defaultMaterial = null;
        }

        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        //Debug.DrawLine(ray.origin, transform.forward, Color.red);
        if (Physics.Raycast(ray, out hit, 3f))
        {
            
            var seleccion = hit.transform;
            if (seleccion.CompareTag(etiquetaSeleccion))
            {
                var renderSeleccion = seleccion.GetComponent<Renderer>();
                if (renderSeleccion != null)
                {
                    //if(defaultMaterial==null)
                       // defaultMaterial = renderSeleccion.material;
                    //newMaterial = defaultMaterial;
                    renderSeleccion.material.SetColor("_EmissionColor", new Color(0.2f,0.2f,0.2f,1));
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Debug.Log(hit.collider.gameObject.name);
                        if (hit.collider.gameObject.name == "Tesoro")
                        {
                            Debug.Log("HAS GANADO");
                            GameObject.Find("Spawns").GetComponent<Spawner>().enabled = false;
                            enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
                            for (int i = 0; i < enemigos.Length; i++)
                            {
                                Destroy(enemigos[i]);
                            }
                            hit.collider.gameObject.GetComponent<Animator>().enabled = true;
                            preparandoFinal = true;
                        }
                            
                    }
                }

                _seleccion = seleccion;
            }
        }
    }
}