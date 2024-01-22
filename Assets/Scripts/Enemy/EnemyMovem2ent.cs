using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiMovement2 : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    private Healthbar healthBar;

    public BloodEffect bloodEffect;
    public float bloodDuration = 60f;

    public GameObject explosionPrefab; // Prefab de la explosi�n
    public float explosionRadius = 2f; // Radio de la explosi�n
    public int explosionDamage = 100; // Da�o de la explosi�n

    public bool stateExplosion = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar = GetComponentInChildren<Healthbar>();
        if (healthBar != null)
        {
            healthBar.UpdateHealthbar(maxHealth, currentHealth, currentHealth);
        }
    }

    private void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;

    }

    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    public void TomarDa�o(float da�o)
    {
        currentHealth -= da�o;

        if (currentHealth <= 0)
        {
            Explode(); // Llamar a la funci�n Explode cuando la salud llega a cero
            Destroy(gameObject);

        }

        if (healthBar != null)
        {
            healthBar.UpdateHealthbar(maxHealth, currentHealth, currentHealth + da�o);
        }
    }

    void Explode()
    {
        if (bloodEffect != null)
        {
            bloodEffect.ShowBloodEffect(transform.position, bloodDuration);
        }

        // Crear la explosi�n
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Aplicar da�o a los objetos dentro del radio de la explosi�n
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                // Obtener el componente GolpePersonaje
                GolpePersonaje playerScript = collider.GetComponent<GolpePersonaje>();

                if (playerScript != null)
                {
                    // Aplicar da�o al jugador
                    playerScript.TomarDa�o(explosionDamage);
                }
            }
            else if (collider.CompareTag("Enemigo") && collider.gameObject != gameObject)
            {
                // Obtener el componente EnemiMovement2 del enemigo cercano
                EnemiMovement enemyScript = collider.GetComponent<EnemiMovement>();

                if (enemyScript != null)
                {
                    // Aplicar da�o al enemigo cercano
                    enemyScript.TomarDa�o(explosionDamage);
                }
            }
        }

        // Destruir el objeto actual (enemigo explosivo)
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Explode();
            Destroy(gameObject);
        }
    }
}
