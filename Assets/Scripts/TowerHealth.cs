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
    public void TomarDa�o(float da�o)
    {
        currentHealth -= da�o;

        if (currentHealth <= 0)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            DestroyEnemy();
            //Debug.Log(currentHealth);
            //Debug.Log(da�o);
        }

        else
        {
            //healthBar.UpdateHealthbar(maxHealth, currentHealth, currentHealth + da�o);
            Debug.Log("damage" + currentHealth);
            GetComponent<SpriteRenderer>().color = Color.red;


            // Inicia una corutina para ocultar la imagen despu�s de cierto tiempo
            StartCoroutine(HitDamageEffect(.6f));
        }
    }

    IEnumerator HitDamageEffect(float duration)
    {
        Debug.Log("hit");

        // Espera el tiempo especificado antes de ocultar la imagen de sangre
        yield return new WaitForSeconds(duration);

        // Oculta la imagen de sangre despu�s del tiempo especificado
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
