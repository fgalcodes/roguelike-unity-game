using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpikes : MonoBehaviour
{
    public Animator spikesAnimator;
    public int damageAmount = 20;
    public float animationDuration = 0.4f;
    public float activationCooldown = 0.5f;

    private bool hasActivated = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasActivated)
        {
            ActivarTrampa();
            AplicarDanio(other.gameObject);
            hasActivated = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DesactivarTrampaConEspera());
        }
    }

    IEnumerator DesactivarTrampaConEspera()
    {
        yield return new WaitForSeconds(animationDuration);
        DetenerTrampa();
        yield return new WaitForSeconds(activationCooldown);
        hasActivated = false;
    }

    void ActivarTrampa()
    {
        if (spikesAnimator != null)
        {
            spikesAnimator.enabled = true;
            spikesAnimator.SetTrigger("Activate");
        }
    }

    void DetenerTrampa()
    {
        if (spikesAnimator != null)
        {
            spikesAnimator.enabled = false;
        }
    }

    void AplicarDanio(GameObject jugador)
    {
        GolpePersonaje golpePersonaje = jugador.GetComponent<GolpePersonaje>();

        if (golpePersonaje != null)
        {
            golpePersonaje.TomarDaño(damageAmount);
        }
    }
}
