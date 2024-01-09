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

    public void TomarDa�o(float da�o)
    {
        currentHealth -= da�o;

        if (currentHealth <= 0)
        {
            currentState = States.Die;
            DestroyEnemy();
        }

        else
        {
            //healthBar.UpdateHealthbar(maxHealth, currentHealth, currentHealth + da�o);
            Debug.Log("damage");
        }
    }
    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
