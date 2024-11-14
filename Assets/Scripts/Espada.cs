using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidadMinima = 0.1f;
    private Vector3 ultimaPosicionMouse;
    private Vector3 velocidadMouse;
    private Collider2D col;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        col.enabled = SeMueveElMouse();
        AsociarEspadaAlMouse();

    }

    private void AsociarEspadaAlMouse()
    {
        var mousePosicion = Input.mousePosition;
        mousePosicion.z = 10;

        rb.position = Camera.main.ScreenToWorldPoint(mousePosicion);
    }

    private bool SeMueveElMouse()
    {
        Vector3 posicionMouseActual = transform.position;
    
    float desplazamiento = (ultimaPosicionMouse - posicionMouseActual).magnitude;
        ultimaPosicionMouse = posicionMouseActual;

        if (desplazamiento > velocidadMinima)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
