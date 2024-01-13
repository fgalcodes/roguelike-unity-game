using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekpointController : MonoBehaviour
{
    public GameObject rune1;
    public GameObject rune;
    public GameObject glow;

    public float vidaPorSegundo = 1f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            rune1.SetActive(false);
            rune.SetActive(true);
            glow.SetActive(true);

            // Inicia la repetición de la función GanarVida cada segundo
            InvokeRepeating("GanarVida", 0.2f, 0.2f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            rune1.SetActive(true);
            rune.SetActive(false);
            glow.SetActive(false);

            // Detiene la repetición de la función GanarVida
            CancelInvoke("GanarVida");
        }
    }

    private void GanarVida()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");

        GolpePersonaje golpePersonaje = jugador.GetComponent<GolpePersonaje>();

        if (golpePersonaje != null)
        {
            golpePersonaje.AumentarVida(1);
        }
    }
}


