using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{

    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    public void TomarDaño(float daño)
    {
        currentHealth -= daño;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
