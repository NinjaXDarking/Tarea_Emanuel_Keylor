using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Elementos del puntaje")]
    public int puntaje;
    public Text textoPuntaje;
    public int mejorPuntaje;
    public Text textoMejorPuntaje;
    public Text textoMejorPuntajePanel;



    [Header("Elementos GameOver")]
    public GameObject panelGameOver;
    public Text textoPuntajeFinal;


    [Header("Elementos de Sonido")]
    public AudioSource sonidoAumentoPuntaje;
    public AudioSource sonidoBomba;


    public void Awake()
    {
        panelGameOver.SetActive(false);
        PonerMejorPuntaje();
    }

    private void PonerMejorPuntaje()
    {
        mejorPuntaje = PlayerPrefs.GetInt("MejorPuntaje");
        
        textoMejorPuntaje.text = "Mejor: " + mejorPuntaje.ToString();
    }

    public void AumentarPuntaje()
    {
        puntaje += 2;
        textoPuntaje.text = puntaje.ToString();

        if (puntaje > mejorPuntaje)
        {
            PlayerPrefs.SetInt("MejorPuntaje", puntaje);
            textoMejorPuntaje.text = "Mejor: " + puntaje.ToString();
            mejorPuntaje = puntaje;
        }

        if (sonidoAumentoPuntaje != null)
        {
            sonidoAumentoPuntaje.Play();
        }
    }

    public void AlTocarBomba()
    {
        panelGameOver.SetActive(true);
        textoPuntajeFinal.text = "Puntaje :" + puntaje.ToString();
        textoMejorPuntajePanel.text = "Mejor puntaje: " + mejorPuntaje.ToString();
        Time.timeScale = 0;

        if (sonidoBomba != null)
        {
            sonidoBomba.Play();
        }
    }

    public void Reiniciar()
    {
        puntaje = 0;
        textoPuntaje.text = puntaje.ToString();
        Time.timeScale = 1;
        panelGameOver.SetActive(false);

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactivo"))
        {
            Destroy(g);
        }
    }
}

