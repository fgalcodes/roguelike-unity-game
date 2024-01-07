using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekpointController : MonoBehaviour
{
    public GameObject rune1;
    public GameObject rune;
    public GameObject glow;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            rune1.SetActive(false); // Desactiva el rune1
            rune.SetActive(true);   // Activa el rune
            glow.SetActive(true);   // Activa el glow
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            rune1.SetActive(true);  // Activa el rune1
            rune.SetActive(false);  // Desactiva el rune
            glow.SetActive(false);  // Desactiva el glow
        }
    }
}


