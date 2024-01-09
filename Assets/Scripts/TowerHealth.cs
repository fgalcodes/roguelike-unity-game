using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    //[SerializeField] private Healthbar healthBar;
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    public enum States
    {
        Run,
        Attack,
        Die
    }
    public States currentState;

    public void TomarDaño(float daño)
    {
        currentHealth -= daño;

        if (currentHealth <= 0)
        {
            currentState = States.Die;
            DestroyEnemy();
        }

        else
        {
            //healthBar.UpdateHealthbar(maxHealth, currentHealth, currentHealth + daño);
            Debug.Log("damage");
        }
    }
    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
