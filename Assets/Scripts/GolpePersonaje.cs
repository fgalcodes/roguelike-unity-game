using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GolpePersonaje : MonoBehaviour
{
    [SerializeField] int vidas;
    [SerializeField] Slider sliderVidas;

    private bool canTakeDamage = true;
    public float damageCooldown = 1.5f; // Tiempo de cooldown para recibir daño en segundos

    void Start()
    {
        sliderVidas.maxValue = vidas;
        sliderVidas.value = sliderVidas.maxValue;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (canTakeDamage && collision.gameObject.CompareTag("Enemigo"))
        {
            vidas--;
            sliderVidas.value = vidas;
            canTakeDamage = false; // Desactiva la capacidad de recibir daño temporalmente

            if (vidas <= 0)
            {
                gameObject.SetActive(false);
            }

            StartCoroutine(EnableDamageAfterCooldown());
        }
    }

    IEnumerator EnableDamageAfterCooldown()
    {
        yield return new WaitForSeconds(damageCooldown);
        canTakeDamage = true; // Permite recibir daño después del tiempo de cooldown
    }

}
