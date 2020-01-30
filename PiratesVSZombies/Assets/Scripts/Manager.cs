using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Manager : MonoBehaviour {

    bool pausa = false;
    public GameObject jugador;
    public GameObject menuPausa;
    public static int score = 0;
    public GameObject puntuacion;
    public GameObject record;
    int maxScore;
	// Use this for initialization
	void Start () {
        maxScore=PlayerPrefs.GetInt("record");
        score = 0;
        record.GetComponent<UnityEngine.UI.Text>().text = maxScore.ToString();
    }
	
	// Update is called once per frame
	void Update () {

        puntuacion.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        if (score > maxScore) {
            maxScore = score;
            record.GetComponent<UnityEngine.UI.Text>().text = maxScore.ToString();
            PlayerPrefs.SetInt("record", maxScore);
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            pausa = !pausa;
        }

        if (pausa)
        {
            Time.timeScale = 0;
            jugador.GetComponentInChildren<Canon>().enabled = false;
            //jugador.GetComponent<FirstPersonController>().enabled = false;
            menuPausa.SetActive(true);
            Cursor.visible = true;
        }
        else {
            Cursor.visible = false;
            Time.timeScale = 1;
            jugador.GetComponentInChildren<Canon>().enabled = true;
            menuPausa.SetActive(false);
            //jugador.GetComponent<FirstPersonController>().enabled = true;
            
        }
	}

    public void resume() {
        pausa = false;
    }

    public void volverMenu() {
        Application.LoadLevel("MenuPrincipal");
    }
}
