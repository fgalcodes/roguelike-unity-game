using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class GolpePersonaje : MonoBehaviour
{
    [SerializeField] int vidas;
    [SerializeField] Slider sliderVidas;
    public GameObject gameOverPanel;
    public Shoot shootScript;

    private bool canTakeDamage = true;
    public float damageCooldown = 1.5f; // Tiempo de cooldown para recibir daño en segundos

    void Start()
    {
        sliderVidas.maxValue = vidas;
        sliderVidas.value = sliderVidas.maxValue;
        gameOverPanel.SetActive(false);
        shootScript.enabled = true;
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
                Time.timeScale = 0f;
                gameOverPanel.SetActive(true);
                shootScript.enabled = false;
            }

            StartCoroutine(EnableDamageAfterCooldown());
        }
    }

    IEnumerator EnableDamageAfterCooldown()
    {
        yield return new WaitForSeconds(damageCooldown);
        canTakeDamage = true; // Permite recibir daño después del tiempo de cooldown
    }

    // Método para aumentar la vida del personaje
    public void AumentarVida(int cantidad)
    {
        vidas += cantidad;
        sliderVidas.value = vidas;
        //Debug.Log("Vida aumentada en: " + cantidad);
    }
}
