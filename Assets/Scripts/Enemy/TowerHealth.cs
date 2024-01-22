using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    //[SerializeField] private Healthbar healthBar;
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void TomarDaño(float daño)
    {
        currentHealth -= daño;

        if (currentHealth <= 0)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            DestroyEnemy();
            //Debug.Log(currentHealth);
            //Debug.Log(daño);
        }

        else
        {
            //healthBar.UpdateHealthbar(maxHealth, currentHealth, currentHealth + daño);
            Debug.Log("damage" + currentHealth);
            GetComponent<SpriteRenderer>().color = Color.red;


            // Inicia una corutina para ocultar la imagen después de cierto tiempo
            StartCoroutine(HitDamageEffect(.6f));
        }
    }

    IEnumerator HitDamageEffect(float duration)
    {
        Debug.Log("hit");

        // Espera el tiempo especificado antes de ocultar la imagen de sangre
        yield return new WaitForSeconds(duration);

        // Oculta la imagen de sangre después del tiempo especificado
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
