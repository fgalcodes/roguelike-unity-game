using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    public Sprite bloodSprite; // Asigna la imagen de la sangre en el Inspector

    private void Start()
    {
        // Oculta la imagen de sangre al inicio
        GetComponent<SpriteRenderer>().enabled = false;
    }

    public void ShowBloodEffect(Vector3 position, float duration)
    {
        // Muestra la imagen de sangre en la posición proporcionada
        transform.position = position;
        GetComponent<SpriteRenderer>().sprite = bloodSprite;
        GetComponent<SpriteRenderer>().enabled = true;

        // Inicia una corutina para ocultar la imagen después de cierto tiempo
        StartCoroutine(HideBloodAfterDuration(duration));
    }

    IEnumerator HideBloodAfterDuration(float duration)
    {
        // Espera el tiempo especificado antes de ocultar la imagen de sangre
        yield return new WaitForSeconds(duration);

        // Oculta la imagen de sangre después del tiempo especificado
        GetComponent<SpriteRenderer>().enabled = false;
    }
}

